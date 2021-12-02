using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject deathEffect;
	public Catapult_physics mainScript;
	public float health = 0.5f;

	public static int EnemiesAlive = 0;
	public GameObject finalCameraPoint;

	void Start ()
	{
		EnemiesAlive++;
	}

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		if (colInfo.relativeVelocity.magnitude > health & colInfo.gameObject.tag == "Player")
		{
			colInfo.gameObject.GetComponent<Renderer>().enabled = false;
			Die();
			Destroy(colInfo.gameObject.GetComponent<BoxCollider2D>());
			Destroy(colInfo.gameObject);
		}
	}
	

    void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		EnemiesAlive--;
		if (EnemiesAlive <= 0)
		{
			mainScript.levelWon = true;
			mainScript.camFollowScript.followTransform = finalCameraPoint.transform;
			
		}	
	}
}
