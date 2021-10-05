using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavyGnome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D (Collision2D colInfo)
	{
        Destroy(colInfo.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
