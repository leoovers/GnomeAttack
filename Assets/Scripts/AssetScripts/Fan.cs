using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    private Animator m_Anim;
    private BoxCollider2D fan;
    private BoxCollider2D button;
    public GameObject fan2;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        var colliders = GetComponents<BoxCollider2D>();
        fan = colliders[0];
        button = colliders[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.IsTouching(button) & m_Anim.GetCurrentAnimatorStateInfo(0).IsTag("on"))
            {
                m_Anim.SetTrigger("Hit");
                fan.enabled = false;
                fan2.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (collision.IsTouching(button) & m_Anim.GetCurrentAnimatorStateInfo(0).IsTag("off"))
            {
                m_Anim.SetTrigger("HitOn");
                fan.enabled = true;
                fan2.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
