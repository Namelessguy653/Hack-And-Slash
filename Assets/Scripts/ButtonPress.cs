using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonPress : MonoBehaviour

{
    public string sceneName; // Name of the scene to load

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
