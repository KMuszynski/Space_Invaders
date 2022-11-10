using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : MonoBehaviour
{

    private float speed = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        speed = speed * RandomValue();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (transform.position.y > 3.5f)
        {
            transform.position = new Vector3(transform.position.x, 3.499f, transform.position.z);
            speed = speed * (-1);
        }
        if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.499f, transform.position.z);
            speed = speed * (-1);
        }
    }
    private float RandomValue()
    {
        System.Random rd = new System.Random();
        float rand_val = rd.Next(0, 2);
        float x = 1;
        if (rand_val < 0.5f)
        {
            x = -1;
            //Debug.Log("Down");
        }
        else if (rand_val > 0.5f)
        {
            x = 1;
            // Debug.Log("up");
        }
        return x;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        //Destroy(other.gameObject);
    }

}
