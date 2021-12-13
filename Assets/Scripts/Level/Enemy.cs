using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject deathEffect;
	public Catapult_physics mainScript;

	public GameObject finalCameraPoint;

	void Start ()
	{
	}

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		if (colInfo.gameObject.tag == "Player")
		{
			colInfo.gameObject.GetComponent<Renderer>().enabled = false;
			Die();
			Destroy(colInfo.gameObject.GetComponent<BoxCollider2D>());
			Destroy(colInfo.gameObject);
			mainScript.levelWon = true;
			mainScript.camFollowScript.followTransform = finalCameraPoint.transform;
		}
	}
	

    void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);

	}
}
