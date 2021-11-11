using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeOpen : MonoBehaviour
{
    private Animator m_Anim;
    private BoxCollider2D FreezerTrigger;
    private BoxCollider2D FrigeTrigger;
    private BoxCollider2D PhotoTrigger;
    private BoxCollider2D JulgubbeTrigger;
    private BoxCollider2D ArtTrigger;
    private BoxCollider2D FTrigger;
    private BoxCollider2D CalendarTrigger;
    private BoxCollider2D PisaTrigger;
    public Catapult_physics mainScript;
    int Hitcake = 0;
    // Start is called before the first frame update
    void Start()
    {

        m_Anim = GetComponent<Animator>();
        var colliders = GetComponents<BoxCollider2D>();
        FreezerTrigger = colliders[3];
        FrigeTrigger = colliders[2];
        PhotoTrigger = colliders[5];
        FTrigger = colliders[4];
        ArtTrigger = colliders[9];
        JulgubbeTrigger = colliders[8];
        CalendarTrigger = colliders[7];
        PisaTrigger = colliders[6];

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.IsTouching(FrigeTrigger))
            {
                m_Anim.SetTrigger("Hit");
                mainScript.levelWon = true;
            }
            if (collision.IsTouching(FreezerTrigger))
            {
                m_Anim.SetTrigger("Freezer");
            }
            if (collision.IsTouching(PhotoTrigger))
            {
                m_Anim.SetTrigger("Photo");
            }
            if (collision.IsTouching(FTrigger))
            {
                m_Anim.SetTrigger("F");
            }
            if (collision.IsTouching(ArtTrigger))
            {
                m_Anim.SetTrigger("Art");
            }
            if (collision.IsTouching(JulgubbeTrigger))
            {
                m_Anim.SetTrigger("Julgubbe");
            }
            if (collision.IsTouching(CalendarTrigger))
            {
                m_Anim.SetTrigger("Calendar");
            }
            if (collision.IsTouching(PisaTrigger))
            {
                m_Anim.SetTrigger("Pisa");
            }


        }
    }
   
}
