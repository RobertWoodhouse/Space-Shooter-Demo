using UnityEngine;
using System.Collections;

public class PlayerDestruction : MonoBehaviour 
{
	public Transform 				shipExplosionPrefab;
	public GameObject 				shipP1;
	public GameObject 				shipP2;

	private PlayerMovement 			_playerMovementP1;
	private PlayerMovement 			_playerMovementP2;

	private static GameController 	_GAME_CONTROLLER;

	void Start () 
	{
		_playerMovementP1 = shipP1.GetComponent<PlayerMovement>();
		_playerMovementP2 = shipP2.GetComponent<PlayerMovement>();

		if (_GAME_CONTROLLER == null)
		{
			_GAME_CONTROLLER = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		}
		else
		{
			return;
		}
	}
	
	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "ProjectileP2" && gameObject.tag == "ShipP1")
		{
			//KillPlayer(_playerMovementP1);
			KillPlayer();
			shipP1 = GameObject.FindGameObjectWithTag("ShipP1"); //TODO: Change after respawn yield is added
			Destroy(collider.gameObject);
			Instantiate (shipExplosionPrefab, transform.position, Quaternion.identity);
			_GAME_CONTROLLER.RespawnPlayer(_GAME_CONTROLLER.shipP1Prefab, _GAME_CONTROLLER.spawnPointA);
		}

		if (collider.tag == "ProjectileP1" && gameObject.tag == "ShipP2")
		{
			//KillPlayer(_playerMovementP2);
			KillPlayer();
			shipP2 = GameObject.FindGameObjectWithTag("ShipP2"); //TODO: Change after respawn yield is added
			Destroy(collider.gameObject);
			Instantiate (shipExplosionPrefab, transform.position, Quaternion.identity);
			_GAME_CONTROLLER.RespawnPlayer(_GAME_CONTROLLER.shipP2Prefab, _GAME_CONTROLLER.spawnPointB);
		}
	}
	/*
	public static void KillPlayer (PlayerMovement playerMovement)
	{
		Destroy(playerMovement.gameObject);
		if (playerMovement.gameObject.tag == "ShipP1")
		{
			GameController.S.shipP1Lives--;
			GUI.S.GUIReset("ShipP1");
		}
		if (playerMovement.gameObject.tag == "ShipP2")
		{
			GameController.S.shipP2Lives--;
			GUI.S.GUIReset("ShipP2");
		}
	}
	*/

	public void KillPlayer ()
	{
		Destroy(gameObject);
		if (gameObject.tag == "ShipP1")
		{
			GameController.S.shipP1Lives--;
			GUI.S.GUIReset("ShipP1");
		}
		if (gameObject.tag == "ShipP2")
		{
			GameController.S.shipP2Lives--;
			GUI.S.GUIReset("ShipP2");
		}
	}
}