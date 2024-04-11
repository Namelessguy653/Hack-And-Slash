using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        // Set the current health to the maximum health when the game starts
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        // Reduce the player's current health by the damage amount
        currentHealth -= damageAmount;

        // Check if the player's health has dropped to zero or below
        if (currentHealth <= 0)
        {
            // Player has died
            Die();
        }
    }

    void Die()
    {
        // Perform actions when the player dies, e.g., play death animation, respawn logic, etc.
        Debug.Log("Player has died!");
        // For example, you might want to reload the scene or show a game over screen.
    }
}
