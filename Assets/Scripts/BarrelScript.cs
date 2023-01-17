using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    private TrackPlayerHorizontally trackPlayerScript;
    private MoveLeft moveLeftScript;
    public float trackingTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        trackPlayerScript = GetComponent<TrackPlayerHorizontally>();
        moveLeftScript = GetComponent<MoveLeft>();
        StartCoroutine(PlayerTracking());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        SpawnManager.barrelDestroyed = true;
    }
    IEnumerator PlayerTracking()
    {
        moveLeftScript.enabled = false;
        moveLeftScript.enabled = false;
        yield return new WaitUntil(() => SetPositionFromLeft.destinationReached == true);
        Debug.Log("Started player-tracking");
        trackPlayerScript.enabled = true;
        yield return new WaitForSecondsRealtime(trackingTime);
        Debug.Log("Ended player-tracking");
        trackPlayerScript.enabled = false;
        moveLeftScript.enabled = true;
    }
}