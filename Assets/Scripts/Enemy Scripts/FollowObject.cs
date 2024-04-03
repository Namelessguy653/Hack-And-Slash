using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public string playerTag = "Player";
    public string npcTag = "PlayerNPC";
    public float moveSpeed = 5f;
    public float visionRange = 10f;

    private GameObject target;
    private Transform player;
    private Transform npc;

    private void Start()
    {
        // Find the player and NPC objects in the scene
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        npc = GameObject.FindGameObjectWithTag(npcTag).transform;

        // Initially, target the player
        target = player.gameObject;
    }

    private void Update()
    {
        // Check if the player or NPC is within line of sight
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (target.transform.position - transform.position).normalized, out hit, visionRange))
        {
            if (hit.collider.CompareTag(npcTag))
            {
                target = npc.gameObject; // Prioritize NPC if within line of sight
            }
            else if (hit.collider.CompareTag(playerTag))
            {
                target = player.gameObject; // Fall back to player if NPC is not in line of sight
            }
        }

        // Move towards the target object
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
}

