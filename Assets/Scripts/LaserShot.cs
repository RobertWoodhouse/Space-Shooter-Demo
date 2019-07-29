using UnityEngine;
using System.Collections;

public class LaserShot : MonoBehaviour 
{
	public float 		speed = 1.1f;
	
	void Update () 
	{
		StartCoroutine (Laser());
	}
		
	// Increase the speed of the laser over time			
	IEnumerator Laser()
	{
		for (int i = 0; i < 10; i++)	
		{
			GetComponent<Rigidbody2D>().AddForce(transform.up * (Time.time * speed));

			yield return new WaitForSeconds(0.5f);
		}
	}
}
