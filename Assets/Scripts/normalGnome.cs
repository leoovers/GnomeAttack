using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalGnome : MonoBehaviour
{
    public GameObject crashEffect;
    public AudioClip[] explosionAudio;
    private AudioSource audioSource;
    private float volume = 0.5f;

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
        System.Random rnd = new System.Random();
        int rand = rnd.Next(0, explosionAudio.Length);
        Debug.Log(rand);
        audioSource.clip = explosionAudio[rand];
        audioSource.Play();
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
