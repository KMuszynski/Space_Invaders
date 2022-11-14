using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy1Creator;
    public static bool wave1end = false;
    bool if1 = false;
    public GameObject enemy2Creator;
    public static bool wave2end = false;
    // public static int i=0;
    public static int numberOfWavesTotal = 0;

    // Start is called before the first frame update
    void Start()
    {
      //  SceneManager.LoadScene(sceneName: "SampleScene");
        Instantiate(enemy1Creator);  //Creates enemys of first type
        numberOfWavesTotal++;
    }
    
    // Update is called once per frame
    void Update()   
    {
      /*  if (numberOfWavesTotal >= 3)
        {
            SceneManager.LoadScene(sceneName: "2 Scene");
        } */
        if (wave1end == true)
        {
            Instantiate(enemy2Creator);  //Creates a bomb-dropping baloon
            //Debug.Log("2 wave");
            wave1end = false;
            numberOfWavesTotal++;
        }
        if (Enemy2Script.bombDropped == true)
        {
            Debug.Log("AAA");
            Enemy2Script.bombDropped = false;
            Instantiate(enemy1Creator);
            numberOfWavesTotal++;
        }
    }
}
