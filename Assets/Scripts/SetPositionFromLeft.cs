using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionFromLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 destination;
    public float travelTime = 2;
    public static bool destinationReached = false;
    void Start()
    {
        StartCoroutine(LerpPosition(destination, travelTime));
    }
    IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        destinationReached = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
