using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeOpen : MonoBehaviour
{
    private Animator m_Anim;
    private BoxCollider2D FreezerTrigger;
    private BoxCollider2D FrigeTrigger;
    // Start is called before the first frame update
    void Start()
    {

        m_Anim = GetComponent<Animator>();
        var colliders = GetComponents<BoxCollider2D>();
        FreezerTrigger = colliders[0];
        FrigeTrigger = colliders[3];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.IsTouching(FrigeTrigger))
            {
                m_Anim.SetTrigger("Hit");
            }
            if (collision.IsTouching(FreezerTrigger))
            {
                m_Anim.SetTrigger("Freezer");
            }


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
