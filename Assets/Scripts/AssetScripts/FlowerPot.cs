using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPot : MonoBehaviour
{
    private Animator m_Anim;
    public Catapult_physics mainScript;
    int hit = 0;



    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }


    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hit++;
            m_Anim.SetTrigger("Hit");

            if(hit == 2)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                mainScript.levelWon = true;
                mainScript.camFollowScript.followTransform = this.transform;

            }
        }
    }
}
