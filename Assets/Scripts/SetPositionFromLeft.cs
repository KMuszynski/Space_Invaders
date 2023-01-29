using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionFromLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 destination;
    public float travelTime = 2;
    public bool destinationReached = false;
    void Start()
    {
        StartCoroutine(LerpPosition());
    }
    IEnumerator LerpPosition()
    {
        float time = 0;
        Vector2 startPosition = transform.position;
        while (time < travelTime)
        {
            transform.position = Vector2.Lerp(startPosition, destination, time / travelTime);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = destination;
        destinationReached = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
