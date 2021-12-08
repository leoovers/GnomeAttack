using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapejuice : MonoBehaviour
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ScoreManager.levelScore += 100;
            m_Anim.SetTrigger("Hit");
            Destroy(this.GetComponent<BoxCollider2D>());

        }
    }
}
