using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    private SetPositionFromLeft setPosScript;
    private MoveUpAndDown moveUpDownScript;
    private GameObject[] BasicEnemies;
    private float xPlace;
    public float distanceBetweenTwoenemies = 1;
    private bool notFoundXPos = true;
    private bool settingPos = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
        setPosScript = GetComponent<SetPositionFromLeft>();
        moveUpDownScript = GetComponent<MoveUpAndDown>();
        StartCoroutine(EnemySetup());
    }
    IEnumerator EnemySetup()
    {
        moveUpDownScript.enabled = false;
        setPosScript.enabled = false;
        BasicEnemies = GameObject.FindGameObjectsWithTag("BasicEnemy");
        do
        {
            xPlace = Random.Range(-7f, 9f);
            for(int i = 0; i < BasicEnemies.Length; i++)
            {
                if (BasicEnemies.Length == 1)
                {
                    notFoundXPos = false;
                }
                else if ((BasicEnemies[i].transform.position.x + distanceBetweenTwoenemies < xPlace || BasicEnemies[i].transform.position.x - distanceBetweenTwoenemies > xPlace) && !ReferenceEquals(gameObject, BasicEnemies[i]))
                {
                    notFoundXPos = false;
                }
            }
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
