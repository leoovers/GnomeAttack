using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator m_Anim;
	public GameObject winPanel;
	public GameObject deathEffect;
	public GameObject finalCameraPoint;
	public CameraFollow camScript;
	public Catapult_physics mainScript;
	// How long the player needs to stay at location
	public float timerCountDown = 3;
	// Is the player currently at location
	private bool isPlayerColliding = false;

	// Use this for initialization
	void Start()
	{
		m_Anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//  timerCountDown = 5.0f;
		if (collision.gameObject.tag == "Stickable")
		{
			Debug.Log("Player Entered");
			isPlayerColliding = true;
		}
	}

	void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Stickable" && isPlayerColliding == true)
		{
			timerCountDown -= Time.deltaTime;
			if (timerCountDown < 0)
			{
				timerCountDown = 0;
			}
			if (timerCountDown <= 0)
			{
				mainScript.levelWon = true;
				StartCoroutine(Win());
				m_Anim.SetTrigger("Hit");
			}

		}
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Stickable")
		{
			Debug.Log("Player Exited");
			isPlayerColliding = false;
			timerCountDown = 3;
		}
	}

	IEnumerator Win()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		camScript.followTransform = finalCameraPoint.transform;
		yield return new WaitForSeconds(1f);
		winPanel.SetActive(true);
	}
}
