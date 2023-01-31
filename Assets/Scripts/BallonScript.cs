using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonScript : MonoBehaviour
{
    private TrackPlayerVertically trackPlayerVertically;
    private SetPositionFromLeft setPosFromLeft;
    private MoveUp moveUp;
    private DestroyOutOfBounds destroyOutOfBounds;
    public GameObject bomb;
    public float trackingTime = 2;
    public bool balloonFinished = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        trackPlayerVertically = GetComponent<TrackPlayerVertically>();
        setPosFromLeft = GetComponent<SetPositionFromLeft>();
        moveUp = GetComponent<MoveUp>();
        destroyOutOfBounds = GetComponent<DestroyOutOfBounds>();
        trackPlayerVertically.enabled = false;
        moveUp.enabled = false;
        destroyOutOfBounds.enabled = false;
        setPosFromLeft.enabled = true;
        yield return new WaitUntil(() => setPosFromLeft.destinationReached == true);
        trackPlayerVertically.enabled = true;
        setPosFromLeft.enabled = false;
        yield return new WaitForSecondsRealtime(trackingTime);
        trackPlayerVertically.enabled = false;
        Instantiate(bomb, new Vector2(transform.position.x, transform.position.y), bomb.transform.rotation);
        moveUp.enabled = true;
        destroyOutOfBounds.enabled = true;
        balloonFinished = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
