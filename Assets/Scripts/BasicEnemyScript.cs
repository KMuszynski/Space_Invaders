using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    private SetPositionFromLeft setPosScript;
    private MoveUpAndDown moveUpDownScript;
    private GameObject[] BasicEnemies;
    public float xPlace;
    private bool notFoundXPos = true;
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
        setPosScript.enabled = false;
        BasicEnemies = GameObject.FindGameObjectsWithTag("BasicEnemy");
        do
        {
            xPlace = Random.Range(-10f, 9f);
            for(int i = 0; i < BasicEnemies.Length; i++)
            {
                if (BasicEnemies.Length == 1)
                {
                    notFoundXPos = false;
                }
                else if (!(BasicEnemies[i].transform.position.x + 1 > xPlace && BasicEnemies[i].transform.position.x - 1 < xPlace) && !ReferenceEquals(gameObject, BasicEnemies[i]))
                {
                    notFoundXPos = false;
                }
            }
        }
        while (notFoundXPos);
        setPosScript.destination = new Vector2(xPlace, 0);
        Debug.Log("Basic Enemy going to x = " + xPlace);
        setPosScript.travelTime = (12 - xPlace) / 5;
        setPosScript.enabled = true;
        moveUpDownScript.enabled = false;
        yield return new WaitUntil(() => setPosScript.destinationReached == true);
        moveUpDownScript.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
