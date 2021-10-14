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
        m_Anim.SetTrigger("Hit");
        Destroy(GetComponent<CircleCollider2D>());
        

    }
}
