using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{

    public float health = 100f;
    [SerializeField]
    UnityEngine.Object destructableRef;
    public Catapult_physics mainScript;
    public GameObject finalCameraPoint;
    public AudioClip glassShatter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void playShatter()
    {
        SoundManager.PlaySound(glassShatter);
    }

    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude >= health & colInfo.collider.CompareTag("Player"))
        {
            ScoreManager.levelScore += 200;
            playShatter();
            explode();
        }
    }

    private void explode()
    {
        mainScript.objectivesDestroyed++;
        GameObject destructable = (GameObject)(Instantiate(destructableRef));

        destructable.transform.position = transform.position;

        Destroy(gameObject);
        if (mainScript.objectivesDestroyed >= 3)
        {
            mainScript.levelWon = true;
            mainScript.camFollowScript.followTransform = finalCameraPoint.transform;
        }

    }
}
