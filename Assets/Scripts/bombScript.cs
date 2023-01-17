using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    public float speed = 5f;
    float czas = 0;

    // Start is called before the first frame update
    void Start()
    {
        czas = 0;
        //gameObject.layer = LayerMask.NameToLayer("Layer2");
    }

    // Update is called once per frame
    void Update()
    {
        czas += Time.deltaTime;
        transform.Translate(Vector3.up * Time.deltaTime * speed * (-1) );
        if (transform.position.y < -6f )
        {
            Destroy(gameObject);
            Enemy2Script.bombDropped = true;
        }
    /*    if (czas > 3)
        {
            Destroy(gameObject);
        } */
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
     //   if (czas>=0.3)
      //  {
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            // Destroy(other.gameObject);
            Debug.Log("trafiony");
            Enemy2Script.bombDropped = true;
        }
           
     //   }
    }
}
