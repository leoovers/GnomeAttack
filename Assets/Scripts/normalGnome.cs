using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalGnome : MonoBehaviour
{
    public GameObject crashEffect;
    public Catapult_physics mainScript;
    public AudioClip[] explosionAudio;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if (!coll.collider.CompareTag("Respawn")) {
            Explode();
        }
    }

    public void PlayExplosion()
    {
        if (audioSource)
        {
            System.Random rnd = new System.Random();
            int rand = rnd.Next(0, explosionAudio.Length);
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
}
