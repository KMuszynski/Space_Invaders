using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHorizontally : MonoBehaviour
{
    public GameObject horizontalProjectile;
    public float shootDelay = 1;
    public float shootRepeat = 2;
    void Shoot()
    {
        Instantiate(horizontalProjectile, transform.position, transform.rotation);
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", shootDelay, shootRepeat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
