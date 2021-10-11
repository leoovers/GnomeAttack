using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMoveR : MonoBehaviour
{
    private Vector3 posA;

    private Vector3 posB;

    private Vector3 nexPos;

    bool facingRight = true;


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
        childTransform.Translate(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        Move();

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
