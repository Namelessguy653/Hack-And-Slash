using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonQuit : MonoBehaviour
{
    private void Start()
    {
        // Find the Button component attached to this GameObject
        Button button = GetComponent<Button>();

        // Add a listener to the button's onClick event
        if (button != null)
        {
            button.onClick.AddListener(QuitApplication);
        }
        else
        {
            Debug.LogError("QuitButton script is attached to a GameObject without a Button component.");
        }
    }

    public void QuitApplication()
    {
        // Quit the application
        Application.Quit();
    }
}
