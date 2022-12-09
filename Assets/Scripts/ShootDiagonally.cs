using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDiagonally : MonoBehaviour
{
    public GameObject diagonalProjectile;
    void Shoot()
    {
        Instantiate(diagonalProjectile, transform.position, Quaternion.Euler(new Vector3(0, 0, -45)));
        Instantiate(diagonalProjectile, transform.position, Quaternion.Euler(new Vector3(0, 0, 45)));
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
