using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public GameObject deathEffect;
    public Catapult_physics mainScript;
    public CameraFollow camScript;
    public GameObject finalCameraPoint;
    private Animator m_Anim;
    private int hitfence;

    void Start()
    {
        hitfence = 0;
        m_Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            print("aitadmg1");
            m_Anim.SetTrigger("Hit");
            hitfence++;
            if(hitfence == 3) {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                
                StartCoroutine(Win());
            }
            
        }

    }

    IEnumerator Win ()
	{
		yield return new WaitForSeconds(1f);
        camScript.followTransform = finalCameraPoint.transform;
        mainScript.levelWon = true;
    
    }
}
