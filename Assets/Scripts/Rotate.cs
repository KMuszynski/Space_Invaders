using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 2;
    private bool rotatingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Dot(transform.up, Vector3.up) < 0)
        {
            if (rotatingLeft)
            {
                transform.eulerAngles = new Vector3(0, 0, 90);
                rotatingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, -90);
                rotatingLeft = true;
            }
        }
        if (rotatingLeft)
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotationSpeed));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -(Time.deltaTime * rotationSpeed)));
        }
    }
}
