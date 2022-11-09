using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Enemy1Controller : MonoBehaviour
{

    public static int numberOfEnemies = 0;
    private float timeRemaining = 0f;
    public static float time1 = 0f;
    public GameObject enemyPrefab;
    int enemyCreatedSuccesfully=0;
    int totalNumberOfEnemiesCreated=0;

    // float enemyRadius = 3f;
    List<int> position = new List<int>();

    int CreateEnemy()
    {
        System.Random rd = new System.Random();
        int rand_x = rd.Next(0, 10);
        int rand_y = rd.Next(-4, 4);
        List<int> integers = new List<int>();

        if (position.Contains(rand_x))
        {
            Debug.Log("did not create enemy");
            return 0;
        }
        else
        { 
            Instantiate(enemyPrefab, new Vector3(rand_x, rand_y, 0), enemyPrefab.transform.rotation);
            position.Add(rand_x);
            numberOfEnemies++;
            totalNumberOfEnemiesCreated++;
            Debug.Log("created enemy");
            return 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        totalNumberOfEnemiesCreated = 0;
       // SpawnManager.wave1end = false;
        CreateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        //counting time
        timeRemaining -= Time.deltaTime;
        time1 += Time.deltaTime;

        //creating enemies
        if (time1 > 1.75f && numberOfEnemies < 3 && totalNumberOfEnemiesCreated<3)
        {
            time1 = 0f;
            do
            {
                enemyCreatedSuccesfully = CreateEnemy();

            } while (enemyCreatedSuccesfully == 0);
        }
        if (totalNumberOfEnemiesCreated >= 3 && numberOfEnemies==0)
        {
            Destroy(gameObject);
            SpawnManager.wave1end = true;
            Debug.Log("Destroy");
        }
    }
}
