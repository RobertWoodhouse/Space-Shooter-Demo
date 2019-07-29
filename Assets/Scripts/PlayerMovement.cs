using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float 			playerSpeed = 2.0f;
	public Animator 		anim;

	public float 			tempSpeed;
	public bool 			speedUpdate = false;

	void Awake () 
	{
		anim = GetComponentInChildren<Animator>();
	}
	
	void FixedUpdate () 
	{
		ControlsDebug ();
	}

	void Update () 
	{
		if (Input.GetKey(KeyCode.F))
		{
			StartCoroutine (EvadeMove());
		}
	}

	// Directional controls
	void ControlsDebug ()
	{
		if (gameObject.tag == "ShipP1")
		{
			if (Input.GetKey(KeyCode.A))
			{
				transform.position += Vector3.left * Time.deltaTime * playerSpeed;
				anim.SetBool("AfterBurnerMove", true);
				// Animate left tilt		
			}

			else
			{
				anim.SetBool("AfterBurnerMove", false);
			} 
			
			if (Input.GetKey(KeyCode.D))
			{
				transform.position += Vector3.right * Time.deltaTime * playerSpeed;
				anim.SetBool("AfterBurnerMove", true);
				// Animate right tilt
			}

			if (Input.GetKey(KeyCode.W))
			{
				transform.position += Vector3.up * Time.deltaTime * playerSpeed;
				anim.SetBool("AfterBurnerMove", true);
			}

			if (Input.GetKey(KeyCode.S))
			{
				transform.position += Vector3.down * Time.deltaTime * playerSpeed;
				anim.SetBool("AfterBurnerMove", true);
			}
		}

		if (gameObject.tag == "ShipP2")
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.position += Vector3.left * Time.deltaTime * playerSpeed;
				anim.SetBool("AfterBurnerMove", true);
				// Animate left tilt		
			}

			else
			{
				anim.SetBool("AfterBurnerMove", false);
			} 
			
			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.position += Vector3.right * Time.deltaTime * playerSpeed;
				anim.SetBool("AfterBurnerMove", true);
				// Animate right tilt
			}

			if (Input.GetKey(KeyCode.UpArrow))
			{
				transform.position += Vector3.up * Time.deltaTime * playerSpeed;
				anim.SetBool("AfterBurnerMove", true);
			}

			if (Input.GetKey(KeyCode.DownArrow))
			{
				transform.position += Vector3.down * Time.deltaTime * playerSpeed;
				anim.SetBool("AfterBurnerMove", true);
			}
		}

		if (Input.GetKey(KeyCode.Escape))
		{
			SceneSelect.Scenes(3);
		}
	}

	// TODO: Complete Evasive maneuver
	IEnumerator EvadeMove ()
	{	
		bool bool1 = false;
		bool bool2 = false;
		bool bool3 = false;

		tempSpeed = playerSpeed;
		bool1 = true;

		if (bool1 == true)
		{
			playerSpeed = 25.0f;
			yield return new WaitForSeconds(0.25f);
			bool2 = true;
		}
		if (bool2 == true)
		{
			playerSpeed = 0.5f;
			yield return new WaitForSeconds(0.15f);
			bool3 = true;
		}
		if (bool3 == true)
		{
			playerSpeed = tempSpeed;
		}
	}
}