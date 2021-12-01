using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour
{
    private Animator m_Anim;
    public Catapult_physics mainScript;
    private int hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = 0;
        m_Anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hit++;
            m_Anim.SetTrigger("Hit");
            if(hit == 2)
            {
                Destroy(this.GetComponent<BoxCollider2D>());
                mainScript.levelWon = true;
            }
        }
    }
}
