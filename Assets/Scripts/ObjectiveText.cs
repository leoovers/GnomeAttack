using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectiveText : MonoBehaviour
{
    public Catapult_physics mainScript;
    private Text objectiveText;

    // Start is called before the first frame update
    void Start()
    {
        objectiveText = GetComponent<Text>();

        Scene currScene = SceneManager.GetActiveScene();
        string currSceneName = currScene.name;
        if (currSceneName == "Level_01")
        {
            objectiveText.text = "Destroy the fence!";
        }
        if (currSceneName == "Level_02")
        {
            objectiveText.text = "Destroy the flowers!";
        }
        if (currSceneName == "Level_03")
        {
            objectiveText.text = "Knock over the grill";
        }
        if (currSceneName == "Level_04")
        {
            objectiveText.text = "Destroy the beehive!";
        }
        if (currSceneName == "Level_05")
        {
            objectiveText.text = "Bully the frogs!";
        }
        if (currSceneName == "Level_06")
        {
            objectiveText.text= "Flood the lawn!";
        }
        if (currSceneName == "Level_07")
        {
            objectiveText.text = "Break the window!";
        }
        if (currSceneName == "Level_08")
        {
            objectiveText.text= "Climb to the window!";
        }
        if (currSceneName == "Level_09")
        {
            objectiveText.text = "Flood the kitchen!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
