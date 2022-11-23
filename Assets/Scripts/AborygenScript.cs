using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AborygenScript : MonoBehaviour
{
    List<int> position = new List<int>();
    public float speed = 3;
    private float time = 0f;
    public GameObject arrowPrefab;
    private bool arrowShot = false;
    public static bool ArrowFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.layer = LayerMask.NameToLayer("Layer2");
        arrowShot = false;
        ArrowFinished = false;

        System.Random rd = new System.Random();
        int rand_x = rd.Next(8, 10);
        int rand_y = rd.Next(-4, 3);

        transform.position = new Vector3(rand_x, rand_y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(PlayerController.playerPositionY > transform.position.y && arrowShot == false)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else if (PlayerController.playerPositionY < transform.position.y && arrowShot == false)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * (-1));
        }
        if(PlayerController.playerPositionY < (transform.position.y + 0.1) && PlayerController.playerPositionY > (transform.position.y - 0.1)&&arrowShot==false)
        {
            Instantiate(arrowPrefab, new Vector3(transform.position.x, transform.position.y, 0), arrowPrefab.transform.rotation);
            arrowShot = true;
            Debug.Log("strza³a");
        }
        if (arrowShot == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * 2);
        }
        if(transform.position.x >12)
        {
            Destroy(gameObject);
        }
    }
}
