using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngleControl : MonoBehaviour
{
    public Catapult_physics mainScript;
    private GameObject arrow;
    private Button minusButton;
    private Button plusButton;

    // Start is called before the first frame update
    void Start()
    {
        minusButton = transform.GetChild(1).gameObject.GetComponent<Button>();
        plusButton = transform.GetChild(2).gameObject.GetComponent<Button>();

        arrow = GameObject.Find("arrow");
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, mainScript.angle);

        minusButton.onClick.AddListener(TaskOnClick_minus);
        plusButton.onClick.AddListener(TaskOnClick_plus);
    }

    void TaskOnClick_plus(){
        Debug.Log ("You have clicked the + button!");
        if (mainScript.angle < 90){
            mainScript.angle = mainScript.angle + 2;
        }
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, mainScript.angle);
    }

    void TaskOnClick_minus(){
        Debug.Log ("You have clicked the - button!");
        if (mainScript.angle > 0){
            mainScript.angle = mainScript.angle - 2;
        }
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, mainScript.angle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("backspace"))
        {
            TaskOnClick_minus();
        }
        if (Input.GetKeyDown("return"))
        {
            TaskOnClick_plus();
        }
    }
}
