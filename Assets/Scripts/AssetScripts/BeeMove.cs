using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMove : MonoBehaviour
{
    private Vector3 posA;

    private Vector3 posB;

    private Vector3 nexPos;

    bool facingRight;


    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;


    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;

    }


    // Update is called once per frame
    void Update()
    {
        
        Move();
        if (childTransform.rotation.y == 0)
        {
            facingRight = false;
        }
        else if (childTransform.rotation.y == 180)
        {
            facingRight = true;
        }

    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
        {
            ChangeDestination();
            flip();
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posA ? posA : posB;
    }

    void flip()
    {
        facingRight = !facingRight;
        childTransform.Rotate(0f, 180f, 0f);
    }

}
