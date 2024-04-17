using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has an EnemyHealth component
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            Debug.Log("Sword Hit");
            // If yes, deduct 10 health from the enemy
            enemyHealth.TakeDamage(10);
        }
    }
}
