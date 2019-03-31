using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth_ : MonoBehaviour
{

    private int startHealth;
    private int currentHealth;

    // Start is called before the first frame update
    private void onEnable()
    {
        currentHealth = startHealth;
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
   
}
