using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treehit : MonoBehaviour
{
    public Catapult_physics mainScript;
    public BeeSpawn beescript;
    private Animator m_Anim;

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
        m_Anim.SetTrigger("Hit");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            m_Anim.SetTrigger("HitBeehive");
            mainScript.levelWon = true;
            beescript.Invoke("SpawnBees", 2f);
            Destroy(GetComponent<CapsuleCollider2D>());
        }
    }
}
