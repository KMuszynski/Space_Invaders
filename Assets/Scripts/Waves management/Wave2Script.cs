using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2Script : MonoBehaviour
{
    public GameObject barrel;
    public GameObject balloon;
    public GameObject rocketship;
    public float xSpawnPos = 11;
    public float upperSpawnBound = 5;
    public float lowerSpawnBound = -5;
    private float yRandSpawnPos;
    private BallonScript ballonScript;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(barrel);
        Instantiate(balloon);
        ballonScript = GameObject.Find("Balloon(Clone)").GetComponent<BallonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballonScript.balloonFinished)
        {
            Destroy(gameObject);
        }
        if (GameObject.Find("Rocketship(Clone)") == null)
        {
            yRandSpawnPos = Random.Range(lowerSpawnBound, upperSpawnBound);
            Instantiate(rocketship, new Vector2(xSpawnPos, yRandSpawnPos), rocketship.transform.rotation);
        }
    }
}
