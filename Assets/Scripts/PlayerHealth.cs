using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthSlider; // Reference to the Slider UI element

    private void Start()
    {
        // Set the current health to the maximum health when the game starts
        currentHealth = maxHealth;

        // Set the initial value of the health slider
        UpdateHealthSlider();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10); // You can adjust the damage value as needed
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took " + damage + " damage. Current Health: " + currentHealth);

        // Update the health slider after taking damage
        UpdateHealthSlider();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform actions when the player dies, e.g., play death animation, respawn logic, etc.
        Debug.Log("Player has died!");
        // For example, you might want to reload the scene or show a game over screen.
    }

    void UpdateHealthSlider()
    {
        // Ensure that health doesn't exceed the maximum health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update the value of the health slider based on current health
        healthSlider.value = (float)currentHealth / maxHealth;
    }
}
