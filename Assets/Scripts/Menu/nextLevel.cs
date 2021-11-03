using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    private Button btn;
    private Scene currScene;
    private string currSceneName;
    private int currSceneNumber;
    private int nextSceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);  // Adds a listener on the button

        currScene = SceneManager.GetActiveScene();
        currSceneName = currScene.name;
        currSceneNumber = Int16.Parse(currSceneName.Substring(currSceneName.Length - 1));
        nextSceneNumber = currSceneNumber + 1; 
    }

    void TaskOnClick()
    {
        if (nextSceneNumber.ToString().Length == 1)
        {
            SceneManager.LoadScene("Level_0" + nextSceneNumber.ToString());
        }
        else
        {
            SceneManager.LoadScene("Level_" + nextSceneNumber.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
