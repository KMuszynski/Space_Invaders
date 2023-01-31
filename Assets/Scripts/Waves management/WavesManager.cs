using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public GameObject wave1Manager;
    public GameObject wave2Manager;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            Instantiate(wave1Manager);
            yield return new WaitUntil(() => GameObject.Find("Wave 1 Manager(Clone)") == null);
            Instantiate(wave2Manager);
            yield return new WaitUntil(() => GameObject.Find("Wave2Manager(Clone)") == null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
