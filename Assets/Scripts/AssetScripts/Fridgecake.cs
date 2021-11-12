using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridgecake : MonoBehaviour
{
    public GameObject finalCameraPoint;
    private Animator m_Anim;
    private int Hitcake;
    public Catapult_physics mainScript;
    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        Hitcake = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Hitcake++;
            m_Anim.SetTrigger("HitCake");
            GetComponent<CapsuleCollider2D>().enabled = false;

            if (Hitcake >= 2)
            {
                mainScript.levelWon = true;
                mainScript.camFollowScript.followTransform = finalCameraPoint.transform;
            }

        }
    }
}
