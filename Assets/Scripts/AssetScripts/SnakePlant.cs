using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePlant : MonoBehaviour
{
    private Animator m_Anim;

 



    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            m_Anim.SetTrigger("Hit");


        }
    }
  
}
