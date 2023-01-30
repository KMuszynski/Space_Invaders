using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1Script : MonoBehaviour
{
    public GameObject basicEnemy;
    public static bool enemySet = false;
    public float xSpawnPos = 11;
    public float upperSpawnBound = 5;
    public float lowerSpawnBound = -5;
    public float numberOfEnemies = 6;
    private float yRandSpawnPos;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            yRandSpawnPos = Random.Range(lowerSpawnBound, upperSpawnBound);
            Instantiate(basicEnemy, new Vector2(xSpawnPos, yRandSpawnPos), basicEnemy.transform.rotation);
            enemySet = false;
            yield return new WaitUntil(() => enemySet == true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
