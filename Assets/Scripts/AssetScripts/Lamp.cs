using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject finalCameraPoint;
    private Animator m_Anim;
    public Catapult_physics mainScript;
    private int Lampdmg = 0;

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
        if (collision.collider.CompareTag("Player"))
        {
            m_Anim.SetTrigger("Hit");

            Lampdmg++;

            if (Lampdmg == 2)
            {
                this.gameObject.AddComponent<Rigidbody2D>();
                Destroy(this.gameObject.GetComponent<PolygonCollider2D>());
                mainScript.objectivesDestroyed++;
                StartCoroutine(Freeze());
            }

            if (mainScript.objectivesDestroyed >= 3)
            {
                mainScript.levelWon = true;
                mainScript.camFollowScript.followTransform = finalCameraPoint.transform;
            }

        }
    }

    IEnumerator Freeze ()
    {
        mainScript.camFollowScript.followTransform = this.transform;
        yield return new WaitForSeconds(1f);
        mainScript.camFollowScript.followTransform = mainScript.newGnome.transform;
    }
}
