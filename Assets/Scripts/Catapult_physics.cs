using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TMPro;

public class Catapult_physics : MonoBehaviour
{
    public CameraFollow camFollowScript;  // Script attached to Main Camera
    public Button plus_button;  //  UI button for angle plus
    public Button minus_button;  // UI button for angle minus
    public Slider powerslider;  // UI slider for launch power control
    public Text angleText;  // UI text for angle in degrees
    public Text powerText;
    public GameObject normalGnome;  // Prefab for spawning a new gnome
    public GameObject arrow;  // Object that indicates launch angle
    public GameObject spawnPoint;  // Empty object that indicates position for spawning gnomes
    public float thrust;  // Amount of force applied in launch
    public int angle = 60;  // Angle in degrees

    private Rigidbody2D nGnomeRigid;
    private GameObject newGnome;
    private bool launched = false;
    private bool sliderStopped = false;
    private int numberOfGnomes;

    void Start()
    {
        Button p_btn = plus_button.GetComponent<Button>();  // Grabs the plus button component
	    p_btn.onClick.AddListener(TaskOnClick_plus);  // Adds a listener on the button

        Button m_btn = minus_button.GetComponent<Button>();  // Grabs the minus button component
	    m_btn.onClick.AddListener(TaskOnClick_minus);  // Adds a listener on the button

        powerslider = powerslider.GetComponent<Slider>();
        powerslider.onValueChanged.AddListener(delegate { thrustValueUpdate(); }); // Adds a listener on the slider

        thrust = 1f;
        numberOfGnomes = 3;

        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);  // Turn arrow in default angle
        newGnome = Instantiate(normalGnome, spawnPoint.transform.position, Quaternion.identity);  // Spawn new gnome based on a prefab
        camFollowScript.followTransform = newGnome.transform;  // Make the spawned gnome the new camera target
    }

    void TaskOnClick_plus(){
		Debug.Log ("You have clicked the + button!");
        if (angle < 100){
            angle = angle + 2;
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
        thrust = powerslider.value;
    }

    void onSliderStop()
    {
        Debug.Log ("Slider stopped");
    }

    void Update()
    {   
        if (!launched)
        {
            if (Input.GetButtonUp("Jump"))
            {
                onLaunch();
            }
            if (Input.GetKeyDown("backspace"))
            {
                TaskOnClick_minus();
            }
            if (Input.GetKeyDown("return"))
            {
                TaskOnClick_plus();
            }
            if (!sliderStopped)
            {
                powerslider.value = Mathf.PingPong(Time.time * 30, 40);  // Add time multiplier to add slider speed
            } 
        }

        angleText.text = angle.ToString() + "°";
        powerText.text = Math.Round((thrust / 40 * 100), 1).ToString() + " %";  
    }

    void onLaunch()
    {
        Vector2 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        nGnomeRigid = newGnome.GetComponent<Rigidbody2D>();
        nGnomeRigid.AddForce(dir * thrust, ForceMode2D.Impulse);
        camFollowScript.xOffset = 3;  // Center the camera a bit more on launch
        launched = true;
        numberOfGnomes--;
        StartCoroutine(Launch());
    }

    IEnumerator Launch ()
	{
		yield return new WaitForSeconds(6f);  // Time before new gnome is spawned after launch

        if (numberOfGnomes > 0)
        {
            newGnome = Instantiate(normalGnome, spawnPoint.transform.position, Quaternion.identity);
            camFollowScript.followTransform = newGnome.transform;
            camFollowScript.xOffset = 6;  // Camera X axis offset before launch
            sliderStopped = false;
            launched = false;
        }
        else
        {
            Debug.Log ("Out of gnomes!");
        }
        }
}