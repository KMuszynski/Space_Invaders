using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts; 
    public static int startingHealth = 3;
    private static int currentHealth;
    public float immortalityTime = 10;
    private bool takedamage = true;

    void Start()
    {
        currentHealth = startingHealth;
    }
    void Update()
    {
        
    }

    IEnumerator hitBreak ()
    {
    takedamage = false;
    yield return new WaitForSecondsRealtime(immortalityTime);
    takedamage = true;
    }

    public void TakeDamage(int damageTaken)
    {
        if(currentHealth > damageTaken &&takedamage)
        {
            hitBreak();
            for (int i = currentHealth - 1; i > currentHealth - 1 - damageTaken; i--)
            {
                currentHealth = PlayerController.playerHealth;
                hearts[i].SetActive(false);
            }
        }
    }
}
