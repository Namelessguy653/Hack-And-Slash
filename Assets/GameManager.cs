using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int fireButtonPressCount = 0;
    public int enemyHealthLostCount = 0;
    public int enemyDeathCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep the GameManager between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager if it exists
        }
    }

    private void Start()
    {
        GameAnalyticsSDK.GameAnalytics.Initialize();
        LoadData();
    }

    public void IncrementFireButtonPressCount()
    {
        fireButtonPressCount++;
        SaveData();
    }

    public void IncrementEnemyHealthLostCount()
    {
        enemyHealthLostCount++;
        SaveData();
    }

    public void IncrementEnemyDeathCount()
    {
        enemyDeathCount++;
        SaveData();
    }

    void SaveData()
    {
        // Save data to PlayerPrefs
        PlayerPrefs.SetInt("FireButtonPressCount", fireButtonPressCount);
        PlayerPrefs.SetInt("EnemyHealthLostCount", enemyHealthLostCount);
        PlayerPrefs.SetInt("EnemyDeathCount", enemyDeathCount);
    }

    public void LoadData()
    {
        // Load data from PlayerPrefs
        fireButtonPressCount = PlayerPrefs.GetInt("FireButtonPressCount", 0);
        enemyHealthLostCount = PlayerPrefs.GetInt("EnemyHealthLostCount", 0);
        enemyDeathCount = PlayerPrefs.GetInt("EnemyDeathCount", 0);
    }
}
