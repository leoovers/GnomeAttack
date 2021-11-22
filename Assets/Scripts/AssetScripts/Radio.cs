using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private Animator m_Anim;
    private BoxCollider2D Ltrigger;
    private BoxCollider2D Rtrigger;
    private BoxCollider2D Antenna;
    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        var colliders = GetComponents<BoxCollider2D>();
        Ltrigger = colliders[1];
        Antenna = colliders[3];
        Rtrigger = colliders[2];

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.IsTouching(Antenna))
            {
                m_Anim.SetTrigger("Antenna");
            }
           
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.IsTouching(Ltrigger))
            {
                m_Anim.SetTrigger("LHit");
            }
            if (collision.collider.IsTouching(Rtrigger))
            {
                m_Anim.SetTrigger("RHit");
            }
        }
    }
}
