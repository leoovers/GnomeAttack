using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private Animator m_Anim;
    private BoxCollider2D Ltrigger;
    private BoxCollider2D Rtrigger;
    private BoxCollider2D Mtrigger;
    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        var colliders = GetComponents<BoxCollider2D>();
        Ltrigger = colliders[1];
        Mtrigger = colliders[2];
        Rtrigger = colliders[3];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.IsTouching(Mtrigger))
            {
                m_Anim.SetTrigger("Hit");
            }
            if (collision.IsTouching(Ltrigger))
            {
                m_Anim.SetTrigger("LHit");
            }
            if (collision.IsTouching(Rtrigger))
            {
                m_Anim.SetTrigger("RHit");
            }
        }

    }
}
