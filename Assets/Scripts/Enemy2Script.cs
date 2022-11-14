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
    public static bool delete = false;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceBomb = 0;
        bombDropped = false;
        bombDropped1=false;
        delete = false;
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
           // Destroy(Enemy2Creator);
           delete = true;
            if1 = true;
        }
        if (transform.position.x < -12 || transform.position.y>6)
        {
            Destroy(gameObject);
        }
        if (bombDropped1 == true)
        {
            timeSinceBomb += Time.deltaTime;
            transform.Translate(Vector3.up * Time.deltaTime * speed * 1.2f );
        }
        if (timeSinceBomb > 3)
        {
           // Destroy(gameObject);
          //  bombDropped = true;
            //SpawnManager.i = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            bombDropped = true;
            delete = true;
        }
        else
        {
            health--;
            Debug.Log(health); 
        }
    }

}
