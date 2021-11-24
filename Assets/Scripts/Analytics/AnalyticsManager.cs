using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance;

    public string levelID;
    //public string stageID;

    private void Awake() {
        MakeSingleton();
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("AnalyticsManagerOnEnable");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name.Contains("Level")) {
            levelID = Regex.Match(scene.name, @"\d+").Value;
            SendStartData();
        }
    }

    public void SendCompletionData() {
        AnalyticsEvent.LevelComplete(levelID);
        Debug.Log("SEND COMPLETION");
    }

    public void SendStartData() {
        AnalyticsEvent.LevelStart(levelID);
        Debug.Log("SEND START");
    }

    /* public void GameOver() {
        Destroy(gameObject);
    } */

    private void MakeSingleton() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDisable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("AnalyticsManagerOnDisable");
    }
}
