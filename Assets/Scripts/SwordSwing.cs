using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    public AnimationClip animationClip; // Reference to the animation clip you want to play

    void Update()
    {
        // Check if Fire1 button is pressed (left mouse button by default)
        if (Input.GetButtonDown("Fire1"))
        {
            // Play the animation if the animation clip is not null
            if (animationClip != null)
            {
                // Create an Animation component on the fly
                Animation animationComponent = gameObject.AddComponent<Animation>();

                // Add the animation clip
                animationComponent.AddClip(animationClip, animationClip.name);

                // Play the animation
                animationComponent.Play(animationClip.name);

                // Destroy the Animation component after the animation finishes
                Destroy(animationComponent, animationClip.length);
            }
            else
            {
                Debug.LogWarning("Animation clip not assigned.");
            }
        }
    }
}
