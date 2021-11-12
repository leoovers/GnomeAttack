using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathtub : MonoBehaviour
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
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_Anim.SetTrigger("Hit");
        }
            
    }
}
