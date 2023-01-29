using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1Script : MonoBehaviour
{
    public GameObject basicEnemy;
    public float xSpawnPos = 11;
    private float yRandSpawnPos;
    public float upperSpawnBound = 5;
    public float lowerSpawnBound = -5;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            yRandSpawnPos = Random.Range(lowerSpawnBound, upperSpawnBound);
            Instantiate(basicEnemy, new Vector2(xSpawnPos, yRandSpawnPos), basicEnemy.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
