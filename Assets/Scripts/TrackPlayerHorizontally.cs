using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerHorizontally : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Ship");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, player.transform.position.y);
    }
}
