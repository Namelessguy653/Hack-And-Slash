using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerHealth playerHealth;

    private void Start()
    {
        // Ensure the healthSlider reference is set
        if (healthSlider == null)
        {
            Debug.LogError("HealthSlider: Health Slider reference is not set!");
            return;
        }

        // Ensure the playerHealth reference is set
        if (playerHealth == null)
        {
            Debug.LogError("HealthSlider: Player Health reference is not set!");
            return;
        }

        // Set the maximum value of the health slider to the player's maximum health
        healthSlider.maxValue = playerHealth.maxHealth;
    }

    private void Update()
    {
        // Update the slider value to match the player's current health
        if (playerHealth != null && healthSlider != null)
        {
            healthSlider.value = playerHealth.currentHealth;
        }
    }
}
