using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    private float speed = 5f;
    float czas = 0;

    // Start is called before the first frame update
    void Start()
    {
        czas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        czas += Time.deltaTime;
        transform.Translate(Vector3.up * Time.deltaTime * speed * (-1) );
        if (transform.position.y < -6f )
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (czas>=0.3)
        {
            Destroy(gameObject);
            // Destroy(other.gameObject);
            Debug.Log("trafiony");
        }
    }
}
