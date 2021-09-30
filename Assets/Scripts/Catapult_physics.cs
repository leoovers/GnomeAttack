using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TMPro;

public class Catapult_physics : MonoBehaviour
{
    Rigidbody2D m_Rigidbody2D;
    public Button plus_button;
    public Button minus_button;
    public Slider powerslider;
    public Text angleText;
    public Text powerText;
    public GameObject arrow;
    public float m_Thrust;
    public int angle = 60;
    private bool launched = false;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        Button p_btn = plus_button.GetComponent<Button>(); //Grabs the plus button component
	    p_btn.onClick.AddListener(TaskOnClick_plus); //Adds a listner on the button

        Button m_btn = minus_button.GetComponent<Button>(); //Grabs the minus button component
	    m_btn.onClick.AddListener(TaskOnClick_minus); //Adds a listner on the button

        powerslider = powerslider.GetComponent<Slider>();
        powerslider.onValueChanged.AddListener(delegate { thrustValueUpdate(); });

        m_Thrust = 1f;

        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle); 
    }

    void TaskOnClick_plus(){
		Debug.Log ("You have clicked the + button!");
        if (angle < 100){
            angle = angle + 2;
            //arrow.transform.Rotate(0.0f, 0.0f, angle, Space.Self);
            arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle); 
        }
	}

    void TaskOnClick_minus(){
		Debug.Log ("You have clicked the - button!");
        if (angle > 0){
            angle = angle - 2;
            arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle); 
        }
	}

    void thrustValueUpdate()
    {
        m_Thrust = powerslider.value;
    }

    void Update()
    {
        if (!launched)
        {
            if (Input.GetButtonUp("Jump"))
            {
                Vector2 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
                m_Rigidbody2D.AddForce(dir * m_Thrust, ForceMode2D.Impulse);
                launched = true;
            }
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

    void FixedUpdate()
    {   
        //angleText3 = GetComponent<TextMeshProUGUI>();
        angleText.text = angle.ToString() + "°";
        powerText.text = Math.Round((m_Thrust / 40 * 100), 1).ToString() + " %";  
    }
}