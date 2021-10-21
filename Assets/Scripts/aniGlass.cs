using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aniGlass : MonoBehaviour
{
    private Animator m_Anim;
    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            m_Anim.SetTrigger("Hit");
            
        }
    }
}
