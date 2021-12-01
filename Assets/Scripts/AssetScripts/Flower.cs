using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
   
    public Catapult_physics mainScript;
    public CameraFollow camScript;
    public GameObject deathEffect;
    private Animator m_Anim;
    private int flowerDmg = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print("Kukkadmg1");
        m_Anim.SetTrigger("Hit");

        flowerDmg++;
        Debug.Log(flowerDmg);

        if (flowerDmg == 2)
        {
            mainScript.objectivesDestroyed++;
            ScoreManager.levelScore += 200;
            StartCoroutine(Freeze());
        }

        if (mainScript.objectivesDestroyed > 3)
        {
            mainScript.levelWon = true;
        }
    }

    IEnumerator Freeze ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
        camScript.followTransform = this.transform;
		yield return new WaitForSeconds(1f);
		camScript.followTransform = mainScript.newGnome.transform;
    }
}
