using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text fireButtonPressText;
    public TMP_Text enemyHealthLostText;
    public TMP_Text enemyDeathText;

    private void Start()
    {
        // Load the saved data from the GameManager when the scene starts
        GameManager.instance.LoadData();

        // Update the UI elements with the loaded data
        UpdateUI();
    }

    void UpdateUI()
    {
        // Update the UI elements with the data loaded from the GameManager
        fireButtonPressText.text = "Fire Button Pressed: " + GameManager.instance.fireButtonPressCount;
        enemyHealthLostText.text = "Enemy Health Lost: " + GameManager.instance.enemyHealthLostCount;
        enemyDeathText.text = "Enemy Death Count: " + GameManager.instance.enemyDeathCount;
    }
}
