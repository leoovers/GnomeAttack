using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
   
    public Catapult_physics mainScript;

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
         
            StartCoroutine(DestroyGameObj(collision.collider.gameObject));
            


        }
    }

    void DestroyObj(GameObject obj)
    {
        Destroy(obj);
    }

    IEnumerator DestroyGameObj(GameObject obj)
    {
        obj.transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.8f);
        DestroyObj(obj);
        
    }
 

}
