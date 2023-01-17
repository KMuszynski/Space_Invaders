using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy1Creator;
    public GameObject Barrel;
    public static bool wave1end = false;
    public GameObject enemy2Creator;
    public static bool wave2end = false;
    public static bool barrelDestroyed = false;
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
            wave1end = false;
            Instantiate(enemy2Creator);  //Creates a bomb-dropping baloon
            //Debug.Log("2 wave");
            numberOfWavesTotal++;
        }
        if (Enemy2Script.bombDropped == true)
        {
            Enemy2Script.bombDropped = false;
            Instantiate(Barrel);
        }
        if (barrelDestroyed == true)
        {
            barrelDestroyed = false;
            Instantiate(enemy1Creator);
        }
        /*
        if (ArrowScript.aborygenEnd == true)
        {
           // Debug.Log("AAA");
            ArrowScript.barrelEnd = false;
            Instantiate(enemy1Creator);
            numberOfWavesTotal++;
        }*/
    }
}
