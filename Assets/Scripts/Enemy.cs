using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject deathEffect;

	public float health = 1f;

	public static int EnemiesAlive = 0;

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
		}
	}

	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);

		EnemiesAlive--;
		if (EnemiesAlive <= 0){
			Destroy(gameObject);
			StartCoroutine(Victory());
		}
	}

	IEnumerator Victory ()
	{
		Debug.Log ("Level Completed!");
		yield return new WaitForSeconds(2f);
		Debug.Log ("Waited");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}


	// void Reset ()
	// {
		
	// }

}
