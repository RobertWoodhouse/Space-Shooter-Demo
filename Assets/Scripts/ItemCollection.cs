using UnityEngine;
using System.Collections;

public class ItemCollection : MonoBehaviour 
{
	public float 			lifeSpan;

	void Start ()
	{
		lifeSpan = Random.Range(5,8);
	}

	// Destroy item after it's been on the scene for a few seconds
	void Update ()
	{
		Destroy(gameObject, lifeSpan);
	}

	void OnTriggerEnter2D (Collider2D coll) 
	{
		if (coll.tag == "ShipP1" || coll.tag == "ShipP2")
		{
			Destroy(gameObject);
			//Debug.Log("Item collected");
		}
	}
}