using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject deathEffect;
    public Catapult_physics mainScript;
    private Animator m_Anim;

    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            print("aitadmg1");
            m_Anim.SetTrigger("Hit");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            mainScript.levelWon = true;
            StartCoroutine(Win());
        }

    }

    IEnumerator Win ()
	{
		yield return new WaitForSeconds(1f);
        winPanel.SetActive(true);
    
    }
}
