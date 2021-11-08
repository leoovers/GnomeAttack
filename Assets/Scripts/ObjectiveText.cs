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
            objectiveText.text = "Destroy the beehive!";
        }
        if (currSceneName == "Level_5")
        {
            objectiveText.text = "Bully the frogs!";
        }
        if (currSceneName == "Level_6")
        {
            objectiveText.text= "Flood the lawn!";
        }
        if (currSceneName == "Level_7")
        {
            objectiveText.text = "Break the window!";
        }
        if (currSceneName == "Level_8")
        {
            objectiveText.text= "Climb to the window!";
        }
        if (currSceneName == "Level_9")
        {
            objectiveText.text = "Flood the kitchen!";
        }
        if (currSceneName == "Level_10")
        {
            objectiveText.text = "Break the glass!";
        }
        if (currSceneName == "Level_11")
        {
            objectiveText.text = "Break the vase!";
        }
        if (currSceneName == "Level_12")
        {
            objectiveText.text = "Open the fridge!";
        }
        if (currSceneName == "Level_13")
        {
            objectiveText.text = "Destroy the cake!";
        }
        if (currSceneName == "Level_14")
        {
            objectiveText.text = "Tip over the sugar bag!";
        }
        if (currSceneName == "Level_15")
        {
            objectiveText.text = "Mess up the soup!";
        }
        if (currSceneName == "Level_16")
        {
            objectiveText.text = "Reach the door handle!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainScript.levelWon)
        {
            this.gameObject.SetActive(false);
        }
    }
}
