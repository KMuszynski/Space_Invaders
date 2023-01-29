using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    public float upperBound = 5;
    public float lowerBound = -5;
    public float speed = 2;
    private Vector2 upOrDown = new Vector2 (0.0f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > upperBound)
        {
            upOrDown = new Vector2(0.0f, -1f);
        }
        else if (transform.position.y < lowerBound)
        {
            upOrDown = new Vector2(0.0f, 1f);
        }
        transform.Translate(upOrDown* Time.deltaTime * speed);
    }
}
