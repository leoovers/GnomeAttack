using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public Catapult_physics mainScript;
    public GameObject deathEffect;
    private Animator m_Anim;

    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            m_Anim.SetTrigger("Hit");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            mainScript.levelWon = true;
            mainScript.camFollowScript.followTransform = this.transform;
        }
    }
}
