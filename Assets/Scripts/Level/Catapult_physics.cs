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
    public Text angleText;  // UI text for angle in degrees
    public Text gnomesLeft;
    public GameObject lossPanel;
    public GameObject winPanel;
    public GameObject[] gnomes;  // List of prefabs for spawning a new gnome
    public GameObject spawnPoint;  // Empty object that indicates position for spawning gnomes
    public int angle = 60;  // Launch angle in degrees
    public bool levelWon = false;
    public bool levelLost = false;
    public float thrust;

    public GameObject newGnome;
    public AudioClip[] grunt;
    public bool launched = false;
    public int objectivesDestroyed = 0;
    private int numberOfGnomes;
    private int launchNumber;
    private Rigidbody2D nGnomeRigid;
    private GameObject lastGnome;
    private AudioSource nGnomeAudio;
    private float timeLaunched = 0f;
    private float timeSlowed = 0f;

    void Start()
    {
        launchNumber = 0;  // First launch is 0 second is 1 ...

        numberOfGnomes = gnomes.Length;
        gnomesLeft.text = numberOfGnomes.ToString();

        instantiateGnome();
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
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;
                if (touch.position.x > 350)
                {
                    onLaunch();
                }
            }
            if (Input.GetButtonUp("Jump"))
            {
                onLaunch();
            }
        }
        if (launched)
        {
            timeLaunched += Time.deltaTime;
        }
        if (launched & nGnomeRigid.velocity.magnitude < 4)
        {
            timeSlowed += Time.deltaTime;
        }
        else
        {
            timeSlowed = 0f;
        }

        angleText.text = angle.ToString() + "°";
        // powerText.text = Math.Round((thrust / 40 * 100), 1).ToString() + " %";  
    }

    void onLaunch()
    {   
        Debug.Log(launchNumber);
        lastGnome = GameObject.Find("Gnome" + (launchNumber - 1).ToString());
        if (lastGnome)
        {
            Destroy(lastGnome.GetComponent<TrailRenderer>());
        }
        Vector2 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        nGnomeRigid.AddForce(dir * thrust, ForceMode2D.Impulse);
        PlayGrunt();
        launched = true;
        numberOfGnomes--;
        gnomesLeft.text = numberOfGnomes.ToString();
        StartCoroutine(Launch());
    }

    IEnumerator Launch ()
	{
        while (launched)
        {
            if (timeLaunched < 6f & timeSlowed < 1f & !levelWon)
            {
                yield return null;
            }
            else
            {
                break;
            }
        }
        
        if (numberOfGnomes > 0 & !levelWon)
        {   
            yield return new WaitForSeconds(0.5f);
            launchNumber++;
            Destroy(nGnomeAudio);
            if (gnomes[launchNumber])
            {
                instantiateGnome();
            }
            timeLaunched = 0f;
            launched = false;
        }
        else
        {
            if (!levelWon & numberOfGnomes <= 0)
            {
                levelLost = true;
                lossPanel.SetActive(true);
            }
            else
            {   
                yield return new WaitForSeconds(0.5f);
                winPanel.SetActive(true); 
            }
        }
    }
}