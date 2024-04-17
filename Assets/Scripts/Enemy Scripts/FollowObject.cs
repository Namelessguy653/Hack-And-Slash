using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public string playerTag = "Player";
    public string npcTag = "PlayerNPC";
    public float moveSpeed = 5f;
    public Collider detectionCollider; // Collider to detect nearby friendly NPCs or players
    public Transform[] waypoints; // Array of waypoints to follow
    private int currentWaypointIndex = 0; // Index of the current waypoint
    private GameObject target;

    private void Start()
    {
        // Initially, target the first waypoint
        target = waypoints[currentWaypointIndex].gameObject;
    }

    private void Update()
    {
        // Check if there are waypoints to follow
        if (waypoints.Length > 0)
        {
            // If within range of the current waypoint, switch to the next waypoint
            if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                target = waypoints[currentWaypointIndex].gameObject;
            }
        }

        // Move towards the target object
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a friendly NPC or player
        if (other.CompareTag(playerTag) || (other.CompareTag(npcTag) && other != gameObject.GetComponent<Collider>()))
        {
            // Set the target to the friendly NPC or player
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the current target
        if (other.gameObject == target)
        {
            // Reset the target to the next waypoint
            target = waypoints[currentWaypointIndex].gameObject;
        }
    }
}
