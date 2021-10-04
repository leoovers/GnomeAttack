using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TMPro;

public class Catapult_physics : MonoBehaviour
{
    public CameraFollow camFollowScript;
    public Button plus_button;
    public Button minus_button;
    public Slider powerslider;
    public Text angleText;
    public Text powerText;
    public GameObject normalGnome;
    public GameObject arrow;
    public GameObject spawnPoint;
    public float m_Thrust;
    public int angle = 60;

    private Rigidbody2D nGnomeRigid;
    private GameObject newGnome;
    private bool launched = false;
    private bool sliderStopped = false;
    private int numberOfGnomes;

    void Start()
    {
        Button p_btn = plus_button.GetComponent<Button>(); //Grabs the plus button component
	    p_btn.onClick.AddListener(TaskOnClick_plus); //Adds a listner on the button

        Button m_btn = minus_button.GetComponent<Button>(); //Grabs the minus button component
	    m_btn.onClick.AddListener(TaskOnClick_minus); //Adds a listner on the button

        powerslider = powerslider.GetComponent<Slider>();
        powerslider.onValueChanged.AddListener(delegate { thrustValueUpdate(); });

        m_Thrust = 1f;
        numberOfGnomes = 3;

        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        newGnome = Instantiate(normalGnome, spawnPoint.transform.position, Quaternion.identity);
        camFollowScript.followTransform = newGnome.transform;
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
        m_Thrust = powerslider.value;
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
            if (Input.GetKey(KeyCode.LeftControl))
            {
                sliderStopped = true;
                onSliderStop();
            }
            else
            {
                if (!sliderStopped)
                {
                    powerslider.value = Mathf.PingPong(Time.time * 20, 40);  // Add time multiplier to add slider speed
                } 
            }
        }
        //angleText3 = GetComponent<TextMeshProUGUI>();
        angleText.text = angle.ToString() + "°";
        powerText.text = Math.Round((m_Thrust / 40 * 100), 1).ToString() + " %";  
    }

    void onLaunch()
    {
        Vector2 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        nGnomeRigid = newGnome.GetComponent<Rigidbody2D>();
        nGnomeRigid.AddForce(dir * m_Thrust, ForceMode2D.Impulse);
        launched = true;
        numberOfGnomes--;
        StartCoroutine(Launch());
    }

    IEnumerator Launch ()
	{
		// yield return new WaitForSeconds(releaseTime);

		// GetComponent<SpringJoint2D>().enabled = false;
		// this.enabled = false;

		yield return new WaitForSeconds(6f);

        if (numberOfGnomes > 0)
        {
            newGnome = Instantiate(normalGnome, spawnPoint.transform.position, Quaternion.identity);
            camFollowScript.followTransform = newGnome.transform;
        }
        else
        {
            Debug.Log ("Out of gnomes!");
        }

        launched = false;
        sliderStopped = false;

		// if (nextBall != null)
		// {
		// 	nextBall.SetActive(true);
		// } else
		// {
		// 	Enemy.EnemiesAlive = 0;
		// 	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		// }
	
	}
}