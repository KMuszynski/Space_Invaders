using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    private TrackPlayerHorizontally trackPlayerScript;
    private SetPositionFromLeft setPosScript;
    private MoveLeft moveLeftScript;
    public float trackingTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        trackPlayerScript = GetComponent<TrackPlayerHorizontally>();
        setPosScript = GetComponent<SetPositionFromLeft>();
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
        trackPlayerScript.enabled = false;
        yield return new WaitUntil(() => setPosScript.destinationReached == true);
        trackPlayerScript.enabled = true;
        yield return new WaitForSecondsRealtime(trackingTime);
        trackPlayerScript.enabled = false;
        moveLeftScript.enabled = true;
    }
}
