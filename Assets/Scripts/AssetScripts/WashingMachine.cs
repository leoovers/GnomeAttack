using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachine : MonoBehaviour
{
    public Catapult_physics mainScript;
    private Animator m_Anim;
    private BoxCollider2D Ltrigger;
    private BoxCollider2D Rtrigger;
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        var colliders = GetComponents<BoxCollider2D>();
        Ltrigger = colliders[1];
        Rtrigger = colliders[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.IsTouching(Ltrigger))
            {
                m_Anim.SetTrigger("Hit");
            }
            if (collision.collider.IsTouching(Rtrigger))
            {
                m_Anim.SetTrigger("HitR");
                mainScript.levelWon = true;
            }
        }
    }
}
