using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectiveText : MonoBehaviour
{
    public Catapult_physics mainScript;
    private Text objectiveText;
    private string[] ger = new string[]{"one", "two"};

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ger[1]);
        setObjText("Level_1", "Destroy the fence!");
        setObjText("Level_2", "Destroy the flowers!");
        setObjText("Level_3", "Knock over the grill!");
        setObjText("Level_4", "Destroy the beehive!");
        setObjText("Level_5", "Bully the frogs!");
        setObjText("Level_6", "Flood the lawn!");
        setObjText("Level_7", "Break the window!");
        setObjText("Level_8", "Climb to the window!");
        setObjText("Level_9", "Flood the kitchen!");
        setObjText("Level_10", "Break the glass!");
        setObjText("Level_11", "Break the vase!");
        setObjText("Level_12", "Open the fridge!");
        setObjText("Level_13", "Destroy the cake!");
        setObjText("Level_14", "Tip over the sugar bag!");
        setObjText("Level_15", "Mess up the soup!");
        setObjText("Level_16", "Reach the door handle!");
        setObjText("Level_17", "Break the tv!");
        setObjText("Level_18", "Break the Flowerpot!");
        setObjText("Level_19", "Hit down the clock!");
        setObjText("Level_20", "Hit down the painting!");
        setObjText("Level_21", "Drop the curtains!");
        setObjText("Level_22", "Destroy the vitrine!");
        setObjText("Level_23", "Bounce on the sofa and hit the lamps!");
        setObjText("Level_24", "Get to the top of the stairs!");
        setObjText("Level_25", "Break the door!");
        setObjText("Level_26", "Clog the toilet!");
        setObjText("Level_27", "Slide the soaps!");
        setObjText("Level_28", "Flood the tub!");
        setObjText("Level_29", "Soap the bath!");
        setObjText("Level_30", "Hit the ducks!");
        setObjText("Level_31", "Drop the towel!");
    }

    void setObjText(string levelName, string objText)
    {
        objectiveText = GetComponent<Text>();
        
        Scene currScene = SceneManager.GetActiveScene();
        string currSceneName = currScene.name;

        if (currSceneName == levelName)
        {
            objectiveText.text = objText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainScript.levelWon | mainScript.levelLost)
        {
            this.gameObject.SetActive(false);
        }
    }
}
