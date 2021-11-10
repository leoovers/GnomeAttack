using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalGnome : MonoBehaviour
{
    public GameObject crashEffect;
    private Catapult_physics mainScript;
    public AudioClip[] explosionAudio;
    private AudioSource audioSource;
    private TrailRenderer tr;
    private Animator m_Anim;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        mainScript = transform.parent.gameObject.GetComponent<Catapult_physics>();
        tr = GetComponent<TrailRenderer>();
        tr.emitting = true;
    }

    void OnCollisionEnter2D (Collision2D coll) {
        m_Anim.SetBool("Grounded", true);
        if (!coll.collider.CompareTag("Respawn")) {
            Explode();
            if (tr)
            {
                tr.emitting = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }

    public void PlayExplosion()
    {
        if (audioSource)
        {
            System.Random rnd = new System.Random();
            int rand = rnd.Next(0, explosionAudio.Length);
            audioSource.volume = 0.2f;
            audioSource.clip = explosionAudio[rand];
            audioSource.Play();
        }
    }
 
    void Explode() {
        Instantiate(crashEffect, transform.position, Quaternion.identity);
        PlayExplosion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        m_Anim.SetBool("Grounded", false);

    }
}
