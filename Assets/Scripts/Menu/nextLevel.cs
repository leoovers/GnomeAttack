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
    public string b;

    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);  // Adds a listener on the button

        currScene = SceneManager.GetActiveScene();
        currSceneName = currScene.name;
        
        for (int i = 0; i < currSceneName.Length; i++)
        {
            if (Char.IsDigit(currSceneName[i]))
            {
                b += currSceneName[i];
            }
        }
        currSceneNumber = Int16.Parse(b);
        nextSceneNumber = currSceneNumber + 1; 
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Level_" + nextSceneNumber.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
