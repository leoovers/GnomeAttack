using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleHit : MonoBehaviour
{
    private Animator m_Anim;
    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.Invoke("rigid", 0.8f);
        m_Anim.SetTrigger("Hit");

        
        Destroy(GetComponent<CircleCollider2D>());
        

    }

    private void rigid()
    {
        this.gameObject.AddComponent<Rigidbody2D>();
    }
}
