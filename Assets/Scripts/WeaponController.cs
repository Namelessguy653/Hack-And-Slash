using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject pivotPoint; // Reference to the pivot point GameObject
    public GameObject weapon; // Reference to the weapon GameObject
    public float swingForce = 10f; // Force with which the weapon swings

    private bool isSwinging = false; // Flag to check if the weapon is currently swinging

    void Update()
    {
        // Check if right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            // Start swinging the weapon
            SwingWeapon();
        }
    }

    void SwingWeapon()
    {
        if (!isSwinging)
        {
            isSwinging = true;

            // Apply a force to the weapon to simulate swinging
            weapon.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * swingForce, ForceMode.Impulse);

            // Rotate the pivot point around the x-axis
            pivotPoint.transform.Rotate(Vector3.right, 90f, Space.Self);

            // Invoke a method to reset weapon position after swinging
            Invoke("ResetWeaponPosition", 0.2f);
        }
    }

    void ResetWeaponPosition()
    {
        // Reset the rotation of the pivot point
        pivotPoint.transform.localRotation = Quaternion.identity;

        isSwinging = false;
    }
}
