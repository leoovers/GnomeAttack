using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    public Catapult_physics mainScript;
    private Animator m_Anim;
    private BoxCollider2D RDoor;
    private BoxCollider2D LDoor;
    private BoxCollider2D Doors;
    private BoxCollider2D Bclothes;
    private BoxCollider2D Mclothes;
    private BoxCollider2D RDress;
    private BoxCollider2D YDress;
    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        var colliders = GetComponents<BoxCollider2D>();
        LDoor = colliders[0];
        RDoor = colliders[1];
        Doors = colliders[2];
        Bclothes = colliders[3];
        Mclothes = colliders[4];
        RDress = colliders[5];
        YDress = colliders[6];
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Anim.GetCurrentAnimatorStateInfo(2).IsTag("Bclothes") & m_Anim.GetCurrentAnimatorStateInfo(3).IsTag("Mclothes") & 
            m_Anim.GetCurrentAnimatorStateInfo(4).IsTag("RedDress") & m_Anim.GetCurrentAnimatorStateInfo(5).IsTag("YDress"))
        {
            mainScript.levelWon = true;
        }
        if (m_Anim.GetCurrentAnimatorStateInfo(1).IsTag("Rdoor") & m_Anim.GetCurrentAnimatorStateInfo(0).IsTag("Ldoor"))
        {
            this.Invoke("open", 1.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.IsTouching(LDoor))
            {
                m_Anim.SetTrigger("Hit");
                
            }
            if (collision.IsTouching(RDoor))
            {
                m_Anim.SetTrigger("RHit");
                
            }
            if (collision.IsTouching(RDress))
            {
                m_Anim.SetTrigger("RDHit");
              
            }
            if (collision.IsTouching(YDress))
            {
                m_Anim.SetTrigger("YDHit");

            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.IsTouching(Bclothes))
            {
                m_Anim.SetTrigger("BCHit");
                
            }
            if (collision.collider.IsTouching(Mclothes))
            {
                m_Anim.SetTrigger("MCHit");

            }
        }
    }
    private void open()
    {
        LDoor.enabled = false;
        RDoor.enabled = false;
        Doors.enabled = false;
        Bclothes.enabled = true;
        Mclothes.enabled = true;
        RDress.enabled = true;
        YDress.enabled = true;
    }
}
