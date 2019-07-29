using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour 
{
	public string 		shipTag = "<Enter ship tag in inspector>";

	private Vector3 	_ship;
	private Vector2 	_shipDirection;
	private float 		_distance;
	private float 		_xDif;
	private float 		_yDif;

	private float 		_speed;
	private int 		_wall;

	void Start () 
	{
		_wall = 1 << 8;
		_speed = 12.0f;
	}
	
	void Update () 
	{
		MissleTracking();
	}

	// Raycast function to home on enemy
	void MissleTracking ()
	{
		_ship = GameObject.FindGameObjectWithTag(shipTag).transform.position;
		_distance = Vector2.Distance(_ship, transform.position);

		if (_distance < 10.0f)
		{
			_xDif = _ship.x - transform.position.x;
			_yDif = _ship.y - transform.position.y;

			_shipDirection = new Vector2 (_xDif, _yDif);

			if (!Physics2D.Raycast (transform.position, _shipDirection, 5, _wall))
			{
				GetComponent<Rigidbody2D>().AddForce(_shipDirection.normalized * _speed);
			}
		}
	}
}