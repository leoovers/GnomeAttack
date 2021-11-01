using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{
    public Catapult_physics mainScript;
    private HingeJoint2D hinge;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (hinge.jointAngle > 90)
        {
            mainScript.levelWon = true;
            mainScript.camFollowScript.followTransform = this.transform;
        }
    }
}
