using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{
    public Catapult_physics mainScript;
    private HingeJoint2D hinge;
    private Animator m_Anim;


    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hinge.jointAngle > 70)
        {
            mainScript.levelWon = true;
            mainScript.camFollowScript.followTransform = this.transform;
            m_Anim.SetTrigger("Hit");
            
        }
    }
}
