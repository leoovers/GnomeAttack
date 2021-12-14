using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleHit : MonoBehaviour
{
    private Animator m_Anim;
    private CircleCollider2D first;
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        var colliders = GetComponents<CircleCollider2D>();
        first = colliders[0];
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player") & collision.collider.IsTouching(first))
        {
            ScoreManager.levelScore += 200;
            this.Invoke("rigid", 0.8f);
            m_Anim.SetTrigger("Hit");
            first.enabled = false;

        }
        if (collision.collider.CompareTag("apple"))
        {
            this.Invoke("rigid", 0.8f);
            m_Anim.SetTrigger("Hit");
        }



        if (collision.collider.CompareTag("Ground"))
        {
            Destroy(this.gameObject.GetComponent<Rigidbody2D>());

        }
    }

    private void rigid()
    {
        this.gameObject.AddComponent<Rigidbody2D>();
    }
}
