using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy1Creator;
    public static bool wave1end = false;
    bool if1 = false;
    public GameObject enemy2Creator;
    public static bool wave2end = false;
   // public static int i=0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy1Creator);  //Creates enemys of first type
        
    }
    
    // Update is called once per frame
    void Update()   
    {
        if (wave1end == true)
        {
            Instantiate(enemy2Creator);  //Creates a bomb-dropping baloon
            //Debug.Log("2 wave");
            wave1end = false;
        }
        if (Enemy2Script.bombDropped == true)
        {
            Debug.Log("AAA");
            Enemy2Script.bombDropped = false;
            Instantiate(enemy1Creator);
        }
    }
}
