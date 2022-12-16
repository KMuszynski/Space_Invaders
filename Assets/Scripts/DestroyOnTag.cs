using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTag : MonoBehaviour
{
    // Start is called before the first frame update
    public string otherTag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(otherTag))
        {
            Destroy(gameObject);
        }
    }
}
