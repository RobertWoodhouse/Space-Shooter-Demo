using UnityEngine;
using System.Collections;

public class XPCollection : MonoBehaviour 
{
	public int 				xpSpeed = 0;
	public int 				xpRps = 0;
	public int 				nextLevelSpeed = 1;
	public int 				nextLevelRps = 1;
	public int 				levelSpeed = 1;
	public int 				levelRps = 1;

	private WeaponFire 		_weaponFire;
	private PlayerMovement 	_playerMovement;

	void Awake () 
	{
		_weaponFire = GetComponent<WeaponFire>();
		_playerMovement = GetComponent<PlayerMovement>();
	}

	// Collect experience points
	void OnTriggerEnter2D (Collider2D coll) 
	{
		if (coll.tag == "XPSpeed")
		{
			xpSpeed++;
			if (xpSpeed == nextLevelSpeed)
			{
				xpSpeed = 0;
				nextLevelSpeed += 1;
				LevelUpSpeed ();
			}
		}

		if (coll.tag == "XPRps")
		{
			xpRps++;
			if (xpRps == nextLevelRps)
			{
				xpRps = 0;
				nextLevelRps += 1;
				LevelUpRps ();
			}
		}
	}

	void LevelUpSpeed ()
	{
		_playerMovement.playerSpeed += 0.5f;
		levelSpeed++;
		Debug.Log("Speed up");
	}

	void LevelUpRps ()
	{
		_weaponFire.primaryWeapon.fireRate -= 0.1f;
		levelRps++;
		Debug.Log("Fire rate increase");
	}
}