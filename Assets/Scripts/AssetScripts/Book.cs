using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
	private int hit;
	public Catapult_physics mainScript;
	// Start is called before the first frame update
	void Start()
    {
		hit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ground"))
		{

            hit++;
            if (hit == 1)
            {
                mainScript.objectivesDestroyed++;
            }
            if (mainScript.objectivesDestroyed >= 3)
            {
                mainScript.levelWon = true;
            }

        }
	}
}
