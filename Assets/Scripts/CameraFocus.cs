using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour 
{
	private GameObject 	_shipP1;
	private GameObject 	_shipP2;
	private Vector3 	_shipP1Pos;
	private Vector3 	_shipP2Pos;

	// Use this for initialization
	void Start () 
	{
		_shipP1 = GameObject.FindGameObjectWithTag("ShipP1");
		_shipP2 = GameObject.FindGameObjectWithTag("ShipP2");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_shipP1 == null)
		{
			_shipP1 = GameObject.FindGameObjectWithTag("ShipP1");

		}
		if (_shipP2 == null)
		{
			_shipP2 = GameObject.FindGameObjectWithTag("ShipP2");
		}
		else
		{
			_shipP1Pos = _shipP1.transform.position;
			_shipP2Pos = _shipP2.transform.position;
			transform.position = new Vector3((_shipP2Pos.x + _shipP1Pos.x) / 2, (_shipP2Pos.y + _shipP1Pos.y) / 2, 0);
		}
	}
}