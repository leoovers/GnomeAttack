using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject deathEffect;
    public GameObject finalCameraPoint;
    public CameraFollow camScript;
    public Catapult_physics mainScript;
    public AudioClip[] windowAudio;
    private AudioSource audioSource;
    private Animator m_Anim;
    private int hitCount;
    private BoxCollider2D TabTrigger;
    private BoxCollider2D KeyTrigger;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        hitCount = 0;
        var colliders = GetComponents<BoxCollider2D>();
        TabTrigger = colliders[1];
        KeyTrigger = colliders[3];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if (collision.IsTouching(KeyTrigger))
            {
                m_Anim.SetTrigger("HitKey");
            }
            else
            {
                hitCount++;
                Debug.Log("windowdmg1");
                m_Anim.SetTrigger("Hit");
            }
           
            if (hitCount == 2)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                mainScript.levelWon = true;
                StartCoroutine(Win());
                PlayShatter();
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") )
        {
            if (collision.collider.IsTouching(TabTrigger))
            {
                m_Anim.SetTrigger("HitTab");
            }
        }
    }

    public void PlayShatter()
    {
        if (audioSource)
        {
            System.Random rnd = new System.Random();
            int rand = rnd.Next(0, windowAudio.Length);
            audioSource.volume = mainScript.fxVolScript.fxVolume;
            audioSource.clip = windowAudio[rand];
            audioSource.Play();
        }
    }

    IEnumerator Win ()
	{
		yield return new WaitForSeconds(1f);
        camScript.followTransform = finalCameraPoint.transform;
        winPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
