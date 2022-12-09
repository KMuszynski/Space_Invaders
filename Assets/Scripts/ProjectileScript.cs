using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 0.25f;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.layer = LayerMask.NameToLayer("Layer2");
    }

    // Update is called once per frame
    void Update()
    {
        //Poruszanie w prawo i usuwanie po wyjsciu z kadru
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.position.x > 12)
        {
            Destroy(gameObject);
        }
        time += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
      /* if (time < 0.02f)
        {
            return;
        } commmented by Lukasz*/
        if ((!other.CompareTag("Player")) && (!other.CompareTag("Background")))
        {
            Destroy(gameObject);
        }
        //Destroy(other.gameObject);
        //Enemy1Controller.numberOfEnemies--;
    }
}