using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts; 
    public static int startingHealth = 3;
    private static int currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }
    void Update()
    {
        
    }
 
    public void TakeDamage(int damageTaken)
    {
        if(currentHealth < damageTaken)
        {
            //dead
        }
        else
        {
            for (int i = currentHealth - 1; i > currentHealth - 1 - damageTaken; i--)
            {
                currentHealth = PlayerController.playerHealth;
                hearts[i].SetActive(false);
            }
        }
        
        
    }
}
