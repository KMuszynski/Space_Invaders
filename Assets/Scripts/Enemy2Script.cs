using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{


    public float speed = 15f;
    float sterowiecPositionX;
    private bool if1 = false;
    public GameObject bombPrefab;
    public static bool bombDropped1 = false;
    public static bool bombDropped = false;
    float timeSinceBomb = 0;
    float health = 5;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceBomb = 0;
        bombDropped = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * (-1));
        sterowiecPositionX = transform.position.x;
        if ((PlayerController.playerPositionX - 1) < sterowiecPositionX && sterowiecPositionX < (PlayerController.playerPositionX + 1) && if1 == false)
        {
            Instantiate(bombPrefab, new Vector3(transform.position.x, transform.position.y, 0), bombPrefab.transform.rotation);
            bombDropped1 = true;
            if1 = true;
        }
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
        if (bombDropped1 == true)
        {
            timeSinceBomb += Time.deltaTime;
        }
        if (timeSinceBomb > 3)
        {
            Destroy(gameObject);
            bombDropped = true;
            //SpawnManager.i = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            bombDropped = true;
        }
        else
        {
            health--;
            Debug.Log(health); 
        }
    }

}
