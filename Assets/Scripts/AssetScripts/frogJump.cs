using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogJump : MonoBehaviour
{
    private Vector3 posA;

    private Vector3 posB;

    private Vector3 nexPos;

    public bool enter;
    public Frog jump;
   


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
        enter = false;

    }


    // Update is called once per frame
    void Update()
    {
        if (enter == true)
        {
            Move();
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enter = true;
            this.Invoke("timed", 1.2f);
            jump.Invoke("Jump", 0f);
            jump.Invoke("NoJump", 0.3f);

        }
        
        
    }
    private void timed()
    {
        enter = false;
        nexPos = posB;
    }

    private void Move()
    {
        
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nexPos = posA;
    }


}
