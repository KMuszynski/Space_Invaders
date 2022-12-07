using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed = 10.0f;
    private float timeRemaining = 0.0f;
    public GameObject projectilePrefab;
    public GameObject gameOverPrefab;
    public static float playerPositionX;
    public static float playerPositionY;
    public static int playerHealth = 3;
    public static float timeFromStart = 0f;
    public HeartSystem heartSystem;

    // Start is called before the first frame update

    void Start()
    {
        transform.position = new Vector3(-8f, 0, 0);
        gameObject.SetActive(true);
        //gameObject.layer = LayerMask.NameToLayer("Layer2");
    }
    // Update is called once per frame
    void Update()
    {
        timeFromStart += Time.deltaTime;
        timeRemaining -= Time.deltaTime;
        // Ruch gracza
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
        // Strzelanie
        if (Input.GetKey(KeyCode.Space) && timeRemaining < 0)
        {
            timeRemaining = 0.25f;
            Instantiate(projectilePrefab, transform.position + new Vector3(1.75f, 0, 0), projectilePrefab.transform.rotation);
        }
        //boundary's
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(-9.9999f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 10)
        {
            transform.position = new Vector3(9.9999f, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.499f, transform.position.z);
        }
        else if (transform.position.y > 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.499f, transform.position.z);
        }

        playerPositionX = transform.position.x;
        playerPositionY = transform.position.y;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Enemy")||other.CompareTag("Sterowiec") || other.CompareTag("Arrow") || other.CompareTag("Aborygen") || other.CompareTag("Bomb") || other.CompareTag("EnemyProjectile"))
        {
            
            heartSystem.TakeDamage(1);
            playerHealth--;
            if (playerHealth<1)
            {
                Destroy(gameObject);
                Instantiate(gameOverPrefab,new Vector3(0f, 0, 0), gameOverPrefab.transform.rotation);
            }
            else
            {
                transform.position = new Vector3(-8f, 0, 0);

                /*gameObject.layer = LayerMask.NameToLayer("Deafult");
                StartCoroutine(Wait());
                gameObject.layer = LayerMask.NameToLayer("Layer2");
                StartCoroutine(Wait());
                gameObject.layer = LayerMask.NameToLayer("Deafult");
                StartCoroutine(Wait());
                gameObject.layer = LayerMask.NameToLayer("Layer2");*/
            }
        } 
    }

    IEnumerator Wait()
    {
            yield return new WaitForSeconds(0.5f);
    }
}
