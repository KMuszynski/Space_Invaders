using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTag : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] otherTags;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        for(int i = 0; i < otherTags.Length; i++)
        {
            if (other.CompareTag(otherTags[i]))
            {
                Destroy(gameObject);
            }
        }
    }
}
