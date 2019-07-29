using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour 
{
	public float 		x;
	public float 		y;

	public float 		force;
	public float 		torque;

	public float 		minForce = 1.0f;
	public float 		maxForce = 3.0f;

	public float 		minTorque = 1.0f;
	public float 		maxTorque = 3.0f;

	void Start () 
	{
		Movement();
	}
	
	// Controls object's direction
	void Movement () 
	{
		x = Random.Range (-1.5f, 1.5f);
		y = Random.Range (-1.5f, 1.5f);

		force = Random.Range (minForce, maxForce);
		torque = Random.Range (minTorque, maxForce);

		GetComponent<Rigidbody2D>().AddForce (force * new Vector2 (x, y));
		GetComponent<Rigidbody2D>().AddTorque (torque);
	}
}