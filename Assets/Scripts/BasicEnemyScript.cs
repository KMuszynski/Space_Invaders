using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    private SetPositionFromLeft setPosScript;
    private MoveUpAndDown moveUpDownScript;
    private GameObject[] BasicEnemies;
    private float xPlace;
    public float distanceBetweenTwoEnemies = 1;
    private bool notFoundXPos = true;
    private bool settingPos = false;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        setPosScript = GetComponent<SetPositionFromLeft>();
        moveUpDownScript = GetComponent<MoveUpAndDown>();
        StartCoroutine(EnemySetup());
    }
    IEnumerator EnemySetup()
    {
        moveUpDownScript.enabled = false;
        setPosScript.enabled = false;
        BasicEnemies = GameObject.FindGameObjectsWithTag("BasicEnemy");
        counter = 0;
        do
        {
            xPlace = Random.Range(-7f, 9f);
            notFoundXPos = false;
            for (int i = 0; i < BasicEnemies.Length; i++)
            {
    /*            if (BasicEnemies.Length == 1)
                {
                    notFoundXPos = false;
                }*/
                if (((BasicEnemies[i].transform.position.x > 0 && xPlace < 0) || (BasicEnemies[i].transform.position.x < 0 && xPlace > 0)) && (Mathf.Abs(BasicEnemies[i].transform.position.x - xPlace) < distanceBetweenTwoEnemies) && !GameObject.ReferenceEquals(gameObject, BasicEnemies[i]))
                {
                    notFoundXPos = true;
                }
                else if (((BasicEnemies[i].transform.position.x > 0 && xPlace > 0) || (BasicEnemies[i].transform.position.x < 0 && xPlace < 0)) && (Mathf.Abs(Mathf.Abs(BasicEnemies[i].transform.position.x) - Mathf.Abs(xPlace)) < distanceBetweenTwoEnemies) && !GameObject.ReferenceEquals(gameObject, BasicEnemies[i]))
                {
                    notFoundXPos = true;
                }
            }
            counter += 1;
        }
        while (notFoundXPos);
        setPosScript.destination = new Vector2(xPlace, transform.position.y);
        Debug.Log("Basic Enemy going to x = " + xPlace);
        setPosScript.travelTime = (12 - xPlace) / 5;
        setPosScript.enabled = true;
        settingPos = true;
        yield return new WaitUntil(() => setPosScript.destinationReached == true);
        settingPos = false;
        Wave1Script.enemySet = true;
        moveUpDownScript.enabled = true;
    }
    private void OnDestroy()
    {
        if (settingPos)
        {
            Wave1Script.enemySet = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
