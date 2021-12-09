using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public GameObject deathEffect;
    public Catapult_physics mainScript;
    public GameObject finalCameraPoint;
    private Animator m_Anim;
    public frogJump frog;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            m_Anim.SetTrigger("Hit");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            mainScript.objectivesDestroyed++;
            this.Invoke("die", 2f);
            if (mainScript.objectivesDestroyed == 2)
            {
                mainScript.levelWon = true;
                mainScript.camFollowScript.followTransform = finalCameraPoint.transform;
            }
        }
    }
    private void die()
    {
        Destroy(this.gameObject);
    }
    void Jump()
    {
        m_Anim.SetBool("Jump", true);
        
    }
    void NoJump()
    {
        m_Anim.SetBool("Jump", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
