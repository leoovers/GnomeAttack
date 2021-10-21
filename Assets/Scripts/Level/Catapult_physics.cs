using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using TMPro;

public class Catapult_physics : MonoBehaviour
{
    public CameraFollow camFollowScript;  // Script attached to Main Camera
    public effectVolume fxVolScript;
    public Button plus_button;  //  UI button for angle plus
    public Button minus_button;  // UI button for angle minus
    public Slider powerslider;  // UI slider for launch power control
    public Text angleText;  // UI text for angle in degrees
    // public Text scoreText;
    public Text gnomesLeft;
    public Text objectiveText;
    public GameObject lossPanel;
    public GameObject winPanel;
    public GameObject[] gnomes;  // Prefab for spawning a new gnome
    public GameObject spawnPoint;  // Empty object that indicates position for spawning gnomes
    public GameObject arrow;
    public float thrust;  // Amount of force applied in launch
    public int angle = 60;  // Angle in degrees
    public bool levelWon = false;

    private GameObject lastGnome;
    public GameObject newGnome;
    private Rigidbody2D nGnomeRigid;
    private AudioSource nGnomeAudio;
    public AudioClip[] grunt;
    private bool launched = false;
    private bool sliderStopped = false;
    private int numberOfGnomes;
    public int flowersDestroyed = 0;
    private int launchNumber;
    private float stoppedTime;
    private bool gnomeStopped;

    void Start()
    {
        launchNumber = 0;  // First launch is 0 second is 1 ...
        Button p_btn = plus_button.GetComponent<Button>();  // Grabs the plus button component
	    p_btn.onClick.AddListener(TaskOnClick_plus);  // Adds a listener on the button

        Button m_btn = minus_button.GetComponent<Button>();  // Grabs the minus button component
	    m_btn.onClick.AddListener(TaskOnClick_minus);  // Adds a listener on the button

        powerslider = powerslider.GetComponent<Slider>();
        powerslider.onValueChanged.AddListener(delegate { thrustValueUpdate(); }); // Adds a listener on the slider

        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

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
            objectiveText.text = "Put the gnome in the pot!";
        }
        if (currSceneName == "Level_4")
        {
            objectiveText.text= "Destroy the beehive!";
        }
        if (currSceneName == "Level_5")
        {
            objectiveText.text= "Break the window!";
        }
        if (currSceneName == "Level_6")
        {
            objectiveText.text= "Stack gnomes to reach the window!";
        }
        

        thrust = 10f;
        numberOfGnomes = gnomes.Length;
        gnomesLeft.text = numberOfGnomes.ToString();

        instantiateGnome();
    }

    void TaskOnClick_plus(){
		Debug.Log ("You have clicked the + button!");
        if (angle < 90){
            angle = angle + 2;
        }
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
	}

    void TaskOnClick_minus(){
		Debug.Log ("You have clicked the - button!");
        if (angle > 0){
            angle = angle - 2;
        }
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
	}

    void thrustValueUpdate()
    {
        thrust = powerslider.value;
    }

    void onSliderStop()
    {
        Debug.Log ("Slider stopped");
    }

    void instantiateGnome()
    {
        newGnome = Instantiate(gnomes[launchNumber], spawnPoint.transform.position, Quaternion.identity);  // Spawn new gnome based on a prefab
        newGnome.transform.parent = gameObject.transform;
        newGnome.name = "Gnome" + launchNumber.ToString();
        nGnomeAudio = newGnome.GetComponent<AudioSource>();
        camFollowScript.followTransform = newGnome.transform;
        nGnomeRigid = newGnome.GetComponent<Rigidbody2D>();
    }

    public void PlayGrunt()
    {
        if (nGnomeAudio)
        {
            System.Random rnd = new System.Random();
            int rand = rnd.Next(0, grunt.Length);
            nGnomeAudio.volume = fxVolScript.fxVolume;
            nGnomeAudio.clip = grunt[rand];
            nGnomeAudio.Play();
        }

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
                powerslider.value = (Mathf.Cos(Time.time * 2.5f) + 1.25f) * 20;  // Add time multiplier to add slider speed
            }
        }

        angleText.text = angle.ToString() + "°";
        // powerText.text = Math.Round((thrust / 40 * 100), 1).ToString() + " %";  
    }

    void FixedUpdate()
    {
        if (nGnomeRigid.velocity.magnitude > 5)
        {
            stoppedTime = 0;
        }
        while (nGnomeRigid.velocity.magnitude < 5)
        {
            stoppedTime += Time.deltaTime;
        }
        if (stoppedTime > 1)
        {
            gnomeStopped = true;
        }
    }

    void onLaunch()
    {   
        objectiveText.gameObject.SetActive(false);
        Debug.Log(launchNumber);
        lastGnome = GameObject.Find("Gnome" + (launchNumber - 1).ToString());
        if (lastGnome)
        {
            Destroy(lastGnome.GetComponent<TrailRenderer>());
        }
        Vector2 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        nGnomeRigid.AddForce(dir * thrust, ForceMode2D.Impulse);
        PlayGrunt();
        camFollowScript.xOffset = 3;  // Center the camera a bit more on launch
        camFollowScript.smoothTime = 0.3f;
        launched = true;
        sliderStopped = true;
        gnomeStopped = false;
        numberOfGnomes--;
        gnomesLeft.text = numberOfGnomes.ToString();
        StartCoroutine(Launch());
    }

    IEnumerator Launch ()
	{
        // yield return new WaitForSeconds(0.2f);
        while (!gnomeStopped)
        {
            yield return null;
        }
        
		yield return new WaitForSeconds(2f);  // Time before new gnome is spawned after launch

        if (numberOfGnomes > 0 & !levelWon)
        {   
            launchNumber++;
            Destroy(nGnomeAudio);
            if (gnomes[launchNumber])
            {
                instantiateGnome();
            }
            camFollowScript.xOffset = 6;  // Camera X axis offset before launch
            sliderStopped = false;
            launched = false;
        }
        else
        {
            if (!levelWon)
            {
                lossPanel.SetActive(true);
                Debug.Log ("Out of gnomes!");
            }
            else
            {   
                winPanel.SetActive(true); 
            }
        }
    }
}