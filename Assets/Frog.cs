using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public GameObject deathEffect;
    public Catapult_physics mainScript;
    public GameObject finalCameraPoint;
    private Animator m_Anim;

    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            m_Anim.SetTrigger("Hit");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            mainScript.flowersDestroyed++;
            if (mainScript.flowersDestroyed == 2)
            {
                mainScript.levelWon = true;
                mainScript.camFollowScript.followTransform = finalCameraPoint.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
