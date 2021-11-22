using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour
{
    public Catapult_physics mainScript;
    private Animator m_Anim;
    private BoxCollider2D Lid;
    private BoxCollider2D Flush;
    private BoxCollider2D toilet;
    private BoxCollider2D Lidcol;
    private int hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = 0;
        m_Anim = GetComponent<Animator>();
        var colliders = GetComponents<BoxCollider2D>();
        Lid = colliders[3];
        Flush = colliders[0];
        toilet = colliders[2];
        Lidcol = colliders[1];
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.IsTouching(Flush))
            {
                m_Anim.SetTrigger("Hit");
            }
            if (collision.IsTouching(Lid))
            {
                m_Anim.SetTrigger("LidHit");
                toilet.enabled = true;
                Lidcol.enabled = false;

            }
            if (collision.IsTouching(toilet))
            {
                Destroy(collision.gameObject);
                hit++;
            }
            if (hit == 2) 
            {
                mainScript.levelWon = true;
                mainScript.camFollowScript.followTransform = this.transform;
            }


        }
    }
}