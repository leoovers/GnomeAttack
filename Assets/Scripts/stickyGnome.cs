using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyGnome : MonoBehaviour
{
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D (Collision2D colInfo)
	{
        Destroy(rigid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
