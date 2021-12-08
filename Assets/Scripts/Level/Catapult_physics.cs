using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using TMPro;

public class Catapult_physics : MonoBehaviour
{
    public GameObject ringleader;
    public GameObject RLSpawn;
    private GameObject newRL;
    public GameObject lossPanel;
    public GameObject winPanel;
    public GameObject[] gnomes;  // List of prefabs for spawning a new gnome
    public GameObject spawnPoint;  // Empty object that indicates position for spawning gnomes
    public GameObject newGnome;
    public CameraFollow camFollowScript;  // Script attached to Main Camera
    public effectVolume fxVolScript;
    public Text angleText;  // UI text for angle in degrees
    public Text gnomesLeft;
    public AudioClip[] grunt;
    public AudioClip[] launchAudio;
    public int objectivesDestroyed = 0;
    public float angle = 60f;  // Launch angle in degrees
    public bool launched = false;
    public bool levelWon = false;
    public bool levelLost = false;
    public float thrust;

    private int numberOfGnomes;
    private int launchNumber;
    private Rigidbody2D nGnomeRigid;
    private GameObject lastGnome;
    private AudioSource nGnomeAudio;
    private float timeLaunched = 0f;
    private float timeSlowed = 0f;
    private GameObject launchButton;
    [SerializeField]
    private Button launchBtn;
    private Animator m_Anim;

    void Start()
    {
        m_Anim = GetComponent<Animator>();
        launchNumber = 0;  // First launch is 0 second is 1 ...
        newRL = Instantiate(ringleader, RLSpawn.transform.position, Quaternion.identity);
        numberOfGnomes = gnomes.Length;
        gnomesLeft.text = numberOfGnomes.ToString();
        launchButton = GameObject.Find("LaunchButton");
        launchBtn = launchButton.GetComponent<Button>();
        launchBtn.onClick.AddListener(onLaunchButtonClick);

        instantiateGnome();
    }

    void onLaunchButtonClick()
    {
        if (!launched)
        {
            onLaunch();
        }
    }

    void instantiateGnome()
    {
        newGnome = Instantiate(gnomes[launchNumber], spawnPoint.transform.position, Quaternion.identity);  // Spawn new gnome based on a prefab
        newGnome.transform.parent = gameObject.transform;
        newGnome.name = "Gnome" + launchNumber.ToString();
        nGnomeAudio = newGnome.GetComponent<AudioSource>();
        nGnomeRigid = newGnome.GetComponent<Rigidbody2D>();
        camFollowScript.followTransform = newGnome.transform;
    }

    public void PlayGrunt()
    {
        if (nGnomeAudio)
        {
            SoundManager.PlayRandom(grunt);
            SoundManager.PlayRandom(launchAudio);
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
        }
        if (launched)
        {
            timeLaunched += Time.deltaTime;
        }
        if (launched & nGnomeRigid.velocity.magnitude < 6f)
        {
            timeSlowed += Time.deltaTime;
        }
        else
        {
            timeSlowed = 0f;
        }

        angleText.text = Math.Round(angle,1).ToString() + "°";
    }

    void onLaunch()
    {
        m_Anim.SetTrigger("FHit");
        lastGnome = GameObject.Find("Gnome" + (launchNumber - 1).ToString());
        if (lastGnome)
        {
            Destroy(lastGnome.GetComponent<TrailRenderer>());
        }
        Vector2 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        nGnomeRigid.AddForce(dir * thrust, ForceMode2D.Impulse);
        
        launched = true;
        numberOfGnomes--;
        gnomesLeft.text = numberOfGnomes.ToString();
        StartCoroutine(Launch());
    }

    void UpdatePlayerPrefs()
    {
        Scene currScene = SceneManager.GetActiveScene();
        String currSceneName = currScene.name;
        String substr = "";
        
        for (int i = 0; i < currSceneName.Length; i++)
        {
            if (Char.IsDigit(currSceneName[i]))
            {
                substr += currSceneName[i];
            }
        }
        int currSceneNumber = Int16.Parse(substr);
        
        PlayerPrefs.SetFloat("MusicVolume", SoundManager.ambientVolume);
        PlayerPrefs.SetFloat("fxVolume", SoundManager.fxVolume);
        PlayerPrefs.SetInt("CompletedLevels", currSceneNumber);
        PlayerPrefs.Save();
    }

    IEnumerator Launch ()
	{
        PlayGrunt();

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
                yield return new WaitForSeconds(1.0f);
                UpdatePlayerPrefs();
                lossPanel.SetActive(false);
                winPanel.SetActive(true);
            }
        }
    }
}