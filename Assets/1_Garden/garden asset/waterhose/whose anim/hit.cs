using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    public Catapult_physics mainScript;
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
        print("Waterhose");
        m_Anim.SetBool("Hit", true);
        mainScript.levelWon = true;
        mainScript.camFollowScript.followTransform = this.transform;
    }
}
