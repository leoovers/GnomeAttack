using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class heavyGnome : MonoBehaviour
{
    Collider2D[] inExplosionRadius = null;
    [SerializeField] private float ExplosionForceMulti = 5;
    [SerializeField] private float ExplosionRadius = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Explode()
    {
        inExplosionRadius = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);

        foreach (Collider2D o in inExplosionRadius)
        {
            Rigidbody2D o_rigidbody = o.GetComponent<Rigidbody2D>();
            if (o_rigidbody != null)
            {
                Vector2 distanceVector = o.transform.position - transform.position;
                if (distanceVector.magnitude > 0)
                {
                    float explosionForce = ExplosionForceMulti / distanceVector.magnitude;
                    o_rigidbody.AddForce(distanceVector.normalized * explosionForce);
                }
            }
        }
    }

    void onDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }

    void OnCollisionEnter2D (Collision2D colInfo)
	{
        Explode();
        if (colInfo.gameObject.tag == "Destructable")
        {
            Destroy(colInfo.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
