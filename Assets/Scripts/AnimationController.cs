using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for button press, you can replace "Fire1" with your desired button
        if (Input.GetButtonDown("W"))
        {
            // Trigger the animation by setting the trigger parameter
            animator.SetTrigger("PlayAnimation");
        }
    }
}

