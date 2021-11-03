using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    [SerializeField]
    int health = 1;
    [SerializeField]
    UnityEngine.Object destructableRef;
    public Catapult_physics mainScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            
            health--;
            if(health <= 0)
            {
                explode();
            }
        }
    }

    private void explode()
    {
        mainScript.objectivesDestroyed++;
        GameObject destructable = (GameObject)(Instantiate(destructableRef));

        destructable.transform.position = transform.position;

        Destroy(gameObject);
        if (mainScript.objectivesDestroyed >= 3)
        {
            mainScript.levelWon = true;
        }

    }
}
