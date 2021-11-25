using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public Catapult_physics mainScript;
    private Animator m_Anim;
    private BoxCollider2D body;
    private BoxCollider2D head;
    
    // Start is called before the first frame update
    void Start()
    {
        
        m_Anim = GetComponent<Animator>();
        var colliders = GetComponents<BoxCollider2D>();
        body = colliders[0];
        head = colliders[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.IsTouching(body))
            {
                m_Anim.SetTrigger("Hit");
                

            }
            if (collision.collider.IsTouching(head))
            {
               
                m_Anim.SetTrigger("HatHit");
                head.enabled = false;
                mainScript.objectivesDestroyed++;
            }
            if (mainScript.objectivesDestroyed == 3)
            {
                mainScript.levelWon = true;
            }
        }
    }
}
