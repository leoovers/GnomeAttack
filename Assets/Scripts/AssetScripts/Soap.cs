using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soap : MonoBehaviour
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
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
