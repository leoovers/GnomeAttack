using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance;
    private AnalyticsResult analyticsResult;

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
            if(levelID != Regex.Match(scene.name, @"\d+").Value) {
                levelID = Regex.Match(scene.name, @"\d+").Value;
                SendStartData();
            }
        }
    }

    public void SendStartData() {
        //AnalyticsEvent.LevelStart(levelID);
        analyticsResult = AnalyticsEvent.Custom("level_start", new Dictionary<string, object>
        {
            {"level_id", levelID},
            //possible other data like tries or time taken to beat the level.
        });

        Debug.Log("SEND START RESULT AND LEVEL ID: " + analyticsResult + levelID);
    }

    public void SendCompletionData() {
        //analyticsResult = AnalyticsEvent.LevelComplete(levelID);
        analyticsResult = AnalyticsEvent.Custom("level_complete", new Dictionary<string, object>
        {
            {"level_id", levelID},
            //possible other data like tries or time taken to beat the level.
        });

        Debug.Log("SEND COMPLETION RESULT AND LEVEL ID: " + analyticsResult + levelID);
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
