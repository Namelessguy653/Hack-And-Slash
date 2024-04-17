using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 10;
    private int currentHealth;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Hit Registered");
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implement death behavior here, like destroying the enemy object.
        Destroy(gameObject);
    }
}

