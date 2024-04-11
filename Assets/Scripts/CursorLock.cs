using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorLock : MonoBehaviour
{
    void Start()
    {
        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        // Hide the cursor
        Cursor.visible = false;
    }
}
