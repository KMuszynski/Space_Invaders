using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public GameObject wave1Manager;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(wave1Manager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
