using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private int previousScore;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        Scene currScene = SceneManager.GetActiveScene();
        previousScore = PlayerPrefs.GetInt(currScene.name + "score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.levelScore > previousScore)
        {
            txt.text = "New high score! " + ScoreManager.levelScore.ToString();
        }
        else
        {
            txt.text = "Score: " + ScoreManager.levelScore.ToString();
        }
    }
}
