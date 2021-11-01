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
        if (currSceneName == "Level_1")
        {
            objectiveText.text = "Destroy the fence!";
        }
        if (currSceneName == "Level_2")
        {
            objectiveText.text = "Destroy the flowers!";
        }
        if (currSceneName == "Level_3")
        {
            objectiveText.text = "Knock over the grill";
        }
        if (currSceneName == "Level_4")
        {
            objectiveText.text= "Destroy the beehive!";
        }
        if (currSceneName == "Level_5")
        {
            objectiveText.text= "Bully the frogs!";
        }
        if (currSceneName == "Level_6")
        {
            objectiveText.text= "Flood the lawn!";
        }
        if (currSceneName == "Level_7")
        {
            objectiveText.text= "Break the window!";
        }
        if (currSceneName == "Level_8")
        {
            objectiveText.text= "Climb to the window!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainScript.launched)
        {
            objectiveText.gameObject.SetActive(false);
        }
    }
}
