using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridgecake : MonoBehaviour
{
    public GameObject finalCameraPoint;
    private Animator m_Anim;
    private int Hitcake;
    public Catapult_physics mainScript;
    private BoxCollider2D FreezerTrigger;
    private BoxCollider2D Cake1;
    private BoxCollider2D RBox;
    private BoxCollider2D Cake2;
    private BoxCollider2D LBox;
    private BoxCollider2D Cheese;
    private BoxCollider2D Pudding;
    private BoxCollider2D Photo;
    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        Hitcake = 0;
        var colliders = GetComponents<BoxCollider2D>();
        FreezerTrigger = colliders[0];
        Cake1 = colliders[1];
        RBox = colliders[2];
        Cake2 = colliders[3];
        LBox = colliders[6];
        Cheese = colliders[5];
        Pudding = colliders[4];
        Photo = colliders[7];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.IsTouching(Cake1) || collision.collider.IsTouching(Cake2))
            {
                Hitcake++;
                m_Anim.SetTrigger("HitCake");
                Cake1.enabled = false;
                this.Invoke("cake", 0.3f);
            }
            if (collision.collider.IsTouching(RBox))
            {
                m_Anim.SetTrigger("RBox");
            }
            if (collision.collider.IsTouching(FreezerTrigger))
            {
                m_Anim.SetTrigger("Freezer");
            }


            if (Hitcake >= 2)
            {
                mainScript.levelWon = true;
                mainScript.camFollowScript.followTransform = finalCameraPoint.transform;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.IsTouching(LBox))
            {
                m_Anim.SetTrigger("LBox");

            }
            if (collision.IsTouching(Cheese))
            {
                m_Anim.SetTrigger("Cheese");

            }
            if (collision.IsTouching(Pudding))
            {
                m_Anim.SetTrigger("Pudding");

            }
            if (collision.IsTouching(Photo))
            {
                m_Anim.SetTrigger("Photo");

            }
        }
    }
    private void cake()
    {
        Cake2.enabled = true;
    }
}
