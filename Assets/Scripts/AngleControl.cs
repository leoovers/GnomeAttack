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

    void TaskOnClick_plus()
    {
        if (mainScript.angle < 90f){
            mainScript.angle = mainScript.angle + 2f;
        }
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, mainScript.angle);
    }

    void TaskOnClick_minus()
    {
        if (mainScript.angle > 0f){
            mainScript.angle = mainScript.angle - 2f;
        }
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, mainScript.angle);
    }

    void onSwipeUp()
    {
        if (mainScript.angle + SwipeManager.swipeCm < 90f)
        {
            mainScript.angle += SwipeManager.swipeCm;
        }
        else
        {
            mainScript.angle = 90f;   
        }
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, mainScript.angle);
    }

    void onSwipeDown()
    {
        if (mainScript.angle - SwipeManager.swipeCm > 0f)
        {
            mainScript.angle -= SwipeManager.swipeCm;
        }
        else
        {
            mainScript.angle = 0f;   
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

        //if (SwipeManager.IsSwipingUp())
        //{
        //  onSwipeUp();
        //}
        //if (SwipeManager.IsSwipingDown())
        //{
        //    onSwipeDown();
        //}
    }
}
