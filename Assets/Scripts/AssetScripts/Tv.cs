using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tv : MonoBehaviour
{
    public GameObject finalCameraPoint;
    private Animator m_Anim;
    public Catapult_physics mainScript;
    private int Hitcount;
    // Start is called before the first frame update
    void Start()
    {
        Hitcount = 0;
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
            Hitcount++;
            m_Anim.SetTrigger("Hit");

            if(Hitcount >= 3) 
            {
                mainScript.levelWon = true;
                mainScript.camFollowScript.followTransform = finalCameraPoint.transform;
            }

        }
    }
}
