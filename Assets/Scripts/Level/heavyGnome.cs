using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class heavyGnome : MonoBehaviour
{
    public float fieldOfImpact;
    public float force = 5f;
    public LayerMask LayerToHit;
    public GameObject ExplosionEffect;
    public CameraFollow camScript;
    private Rigidbody2D rb;

    private bool exploded;

    // Start is called before the first frame update
    void Start()
    {
        exploded = false;
    }

    void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);

        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

        GameObject ExplosionEffectins = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        StartCoroutine(Camera.main.GetComponent<CameraFollow>().Shake(0.5f, 0.5f));
        Destroy(ExplosionEffectins, 10);
        exploded = true;
        // Destroy(gameObject);
    }

    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }

    void OnCollisionEnter2D (Collision2D colInfo)
	{
        if (!exploded & colInfo.gameObject.tag != "Respawn")
        {
            StartCoroutine(DelayedExplosion());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DelayedExplosion ()
	{
		yield return new WaitForSeconds(0.05f);
        explode();
    }
}
