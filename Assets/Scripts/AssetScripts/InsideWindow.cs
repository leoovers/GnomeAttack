using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideWindow : MonoBehaviour
{
    [SerializeField] private Transform destination;
    private Animator m_Anim;
    private BoxCollider2D Window;
    private BoxCollider2D Handle;



    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        var colliders = GetComponents<BoxCollider2D>();
        Window = colliders[0];
        Handle = colliders[1];
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.IsTouching(Window))
            {
                m_Anim.SetTrigger("Hit");
            }
            if (collision.collider.IsTouching(Handle))
            {
                m_Anim.SetTrigger("Open");
                Window.enabled = false;
                Handle.enabled = false;

            }
        }
    }
    public Transform GetDestination() 
    {
        return destination;
    }
}
