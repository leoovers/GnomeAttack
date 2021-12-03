using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public Catapult_physics mainScript;
    private Animator m_Anim;
    private BoxCollider2D Body;
    private BoxCollider2D Head;
    private int hit;


    // Start is called before the first frame update
    void Start()
    {
        hit = 0;
        m_Anim = GetComponent<Animator>();
        var colliders = GetComponents<BoxCollider2D>();
        Body = colliders[0];
        Head = colliders[1];
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hit++;
            if (collision.collider.IsTouching(Body))
            {
                m_Anim.SetTrigger("Hit");

                if (hit == 2)
                {
                    Body.enabled = false;
                    Head.enabled = false;
                    mainScript.levelWon = true;
                }

            }
            if (collision.collider.IsTouching(Head))
            {
                m_Anim.SetTrigger("HitHead");
                Head.enabled = false;

            }
        }
    }
}
