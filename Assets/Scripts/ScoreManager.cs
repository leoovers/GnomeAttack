using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int levelScore = 0;
    
    public static void saveLevelScore() 
    {
        Scene currScene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt(currScene.name + "score", levelScore);
        PlayerPrefs.Save();
    }
}
