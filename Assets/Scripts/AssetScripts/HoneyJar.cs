using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyJar : MonoBehaviour
{

    
    private Animator m_Anim;


    // Start is called before the first frame update
    void Start()
    {

        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsTag("explode"))
        {
            Destroy(this.GetComponent<BoxCollider2D>());
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            m_Anim.SetTrigger("Hit");
            
        }
    }
}
