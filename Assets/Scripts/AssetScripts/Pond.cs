using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    [SerializeField]
    UnityEngine.Object SplashRef;
    public Catapult_physics mainScript;
    public GameObject gnome;
    // Start is called before the first frame update
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
         
            Destroy(collision.collider.gameObject);
            


        }
    }
 

}
