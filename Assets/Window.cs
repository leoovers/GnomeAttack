using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject deathEffect;
    public GameObject finalCameraPoint;
    public Catapult_physics mainScript;
    public CameraFollow camScript;
    private Animator m_Anim;
    private int hitCount;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        hitCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            hitCount++;
            Debug.Log("windowdmg1");
            m_Anim.SetTrigger("Hit");
            if (hitCount == 2)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                mainScript.levelWon = true;
                StartCoroutine(Win());
            }
        }

    }

    IEnumerator Win ()
	{
		yield return new WaitForSeconds(1f);
        camScript.followTransform = finalCameraPoint.transform;
        winPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
