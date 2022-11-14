using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    public GameObject enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, new Vector3(9f, 4.5f, 0), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy2Script.delete == true)
        {
            Destroy(gameObject);
        }
    }
}
