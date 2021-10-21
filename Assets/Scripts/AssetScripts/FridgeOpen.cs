using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeOpen : MonoBehaviour
{
    private Animator m_Anim;
    private Collider2D cake;
    // Start is called before the first frame update
    void Start()
    {
        cake = GetComponent<CapsuleCollider2D>();
        m_Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_Anim.SetTrigger("Hit");


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            m_Anim.SetTrigger("HitCake");
            GetComponent<CapsuleCollider2D>().enabled = false;


        }
    }
}
