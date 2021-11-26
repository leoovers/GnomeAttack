using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AngleControl : MonoBehaviour
{
    public Catapult_physics mainScript;
    private GameObject arrow;


    // Start is called before the first frame update
    void Start()
    {

        arrow = GameObject.Find("arrow");
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, mainScript.angle);

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
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
