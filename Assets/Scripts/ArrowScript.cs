using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float speed = 3f;
    private float time = 0;
    public static bool aborygenEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        aborygenEnd = false;
        //gameObject.layer = LayerMask.NameToLayer("Layer2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * (-1));
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
            aborygenEnd = true;
            // AborygenScript.ArrowFinished = true;
            Debug.Log("AAAAAAAAAAAAAAAAAAAA");
        }
        time += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (time < 0.02f)
        {
            return;
        }
        Destroy(gameObject);
        aborygenEnd = true;
        //  AborygenScript.ArrowFinished = true;
        Debug.Log("AAAAAAAAAAAAAAAAAAAA");
    }
}
