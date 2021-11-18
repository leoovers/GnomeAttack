using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDestroy : MonoBehaviour
{
    [SerializeField]
    UnityEngine.Object BeeRef;
    private GameObject grandparent;
    // Start is called before the first frame update
    void Start()
    {
        grandparent = this.transform.parent.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            grandparent.AddComponent<Rigidbody2D>();
            this.Invoke("killbee", 3f);
            
        }
        if(collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Stickable"))
        {
            Destroy(grandparent);
            GameObject Bee = (GameObject)(Instantiate(BeeRef));
            Bee.transform.position = transform.position;
        }

    }

 
        
        



}
