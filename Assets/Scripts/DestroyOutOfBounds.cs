using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float leftBound = -12;
    public float downBound = -7;
    public float upBound = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < downBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > upBound)
        {
            Destroy(gameObject);
        }
    }
}
