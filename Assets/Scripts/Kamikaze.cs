using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    public float speed = 3f;
    private float time = 0;
    public static bool KeepOnTargetEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        KeepOnTargetEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * (-1));
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
            KeepOnTargetEnd = true;
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
        KeepOnTargetEnd = true;
        //  KeepOnTargetScript.ArrowFinished = true;
    }
}
