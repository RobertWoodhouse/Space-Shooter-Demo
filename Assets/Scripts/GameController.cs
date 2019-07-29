using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject[]				xp;
	public GameObject[]				weapons;
	public Vector2 					spawnValues;
	public int 						spawnCount = 4;
	public float 					spawnTimer = 10.0f;
	public float 					weaponWait = 4.5f;
	public float 					xpWait = 3.7f;

	public Transform 				shipP1Prefab;
	public Transform 				shipP2Prefab;
	public Transform 				spawnPointA;
	public Transform 				spawnPointB;

	public int 						shipP1Lives = 3;
	public int 						shipP2Lives = 3;

	public static GameController 	S;

	void Start () 
	{
		S = this;
	}

	void Update ()
	{
		spawnTimer -= Time.deltaTime;
		
		if (spawnTimer <= 0.0f) 
		{
			StartCoroutine (SpawnItems (weapons, weaponWait));
			StartCoroutine (SpawnItems (xp, xpWait));
			spawnTimer = 10.0f;
		}

		// Restart Level at death
		if (shipP1Lives == 0 || shipP2Lives == 0)
		{
			SceneSelect.Scenes (2);
		}
	}
	
	// Spawn Weapons and XP
	IEnumerator SpawnItems (GameObject[] itemsArray, float spawnWait)
	{
		for (int i = 0; i < spawnCount; i++)
		{
			Vector2 spawnPosition = new Vector2 (Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y));
			Quaternion spawnRotation = Quaternion.identity;
			int j = Random.Range(0, itemsArray.Length);  
			Instantiate (itemsArray[j], spawnPosition, spawnRotation);
			yield return new WaitForSeconds(spawnWait);
		}
	}
				
	public void RespawnPlayer (Transform shipPrefab, Transform spawnPoint)
	{
		Instantiate (shipPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}


