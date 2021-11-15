using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathtub : MonoBehaviour
{
    
    private Animator m_Anim;
    public SoapBottle soapscript;
    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (soapscript.soap == true)
        {
            m_Anim.SetTrigger("Bubbles");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { 
        
            if (soapscript.soap == true)
            {
                m_Anim.SetTrigger("HitBubbles");
            }
            else 
            {
                m_Anim.SetTrigger("HitNoBubbles");
            }
        }

    }
            
}

