using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUI : MonoBehaviour 
{
	public GameObject 		shipP1Prefab;
	public GameObject 		shipP2Prefab;

	private int 			_ammoP1;
	private int 			_ammoP2;
	private int 			_livesP1;
	private int 			_livesP2;
	private Text 			_guiP1;
	private Text 			_guiP2;
	private WeaponFire 		_weaponFireP1;
	private WeaponFire 		_weaponFireP2;
	private Transform 		_guiP1Object;
	private Transform 		_guiP2Object;
	private int 			_xpSpeedP1;
	private int 			_xpSpeedP2;
	private int 			_xpRpsP1;
	private int 			_xpRpsP2;
	private int 			_nextLevelSpeedP1;
	private int 			_nextLevelSpeedP2;
	private int 			_nextLevelRpsP1;
	private int 			_nextLevelRpsP2;
	private XPCollection 	_xpCollectionP1;
	private XPCollection 	_xpCollectionP2;
	private int 			_levelSpeedP1;
	private int 			_levelSpeedP2;
	private int 			_levelRpsP1;
	private int 			_levelRpsP2;

	static public GUI 		S;

	void Awake () 
	{
		shipP1Prefab = GameObject.FindGameObjectWithTag("ShipP1");
		shipP2Prefab = GameObject.FindGameObjectWithTag("ShipP2");
		_guiP1Object = transform.Find("GUIP1");
		_guiP2Object = transform.Find("GUIP2");
		_guiP1 = _guiP1Object.GetComponent<Text>();
		_guiP2 = _guiP2Object.GetComponent<Text>();
		_weaponFireP1 = shipP1Prefab.GetComponent<WeaponFire>();
		_weaponFireP2 = shipP2Prefab.GetComponent<WeaponFire>();
		_xpCollectionP1 = shipP1Prefab.GetComponent<XPCollection>();
		_xpCollectionP2 = shipP2Prefab.GetComponent<XPCollection>();
	}

	void Start ()
	{
		S = this;
	}
	
	void Update () 
	{
		//Seperate the try/catch ammo and lives updates.
		try
		{
			_ammoP1 = _weaponFireP1.specialWeapon.ammo;
			_ammoP2 = _weaponFireP2.specialWeapon.ammo;
			_livesP1 = GameController.S.shipP1Lives;
			_livesP2 = GameController.S.shipP2Lives;
			_xpSpeedP1 = _xpCollectionP1.xpSpeed;
			_xpSpeedP2 = _xpCollectionP2.xpSpeed;
			_xpRpsP1 = _xpCollectionP1.xpRps;
			_xpRpsP2 = _xpCollectionP2.xpRps;
			_nextLevelSpeedP1 = _xpCollectionP1.nextLevelSpeed;
			_nextLevelSpeedP2 = _xpCollectionP2.nextLevelSpeed;
			_nextLevelRpsP1 = _xpCollectionP1.nextLevelRps;
			_nextLevelRpsP2 = _xpCollectionP2.nextLevelRps;
			_levelSpeedP1 = _xpCollectionP1.levelSpeed;
			_levelSpeedP2 = _xpCollectionP2.levelSpeed;
			_levelRpsP1 = _xpCollectionP1.levelRps;
			_levelRpsP2 = _xpCollectionP2.levelRps;

			if (shipP1Prefab == null)
			{
				shipP1Prefab = GameObject.FindGameObjectWithTag("ShipP1");
			}
			if (shipP2Prefab == null)
			{
				shipP2Prefab = GameObject.FindGameObjectWithTag("ShipP2");
			}
		}
		catch (System.NullReferenceException ex)
		{
			Debug.Log(ex);
		}

		// GUI stats
		_guiP1.text = "Lives: " + _livesP1 + " | Ammo: " + _ammoP1 + 
		" \nSpeed LV" + _levelSpeedP1 + " (XP: " + _xpSpeedP1 + "/" + _nextLevelSpeedP1 + 
		") - Fire Rate LV" + _levelRpsP1 + " (XP: " + _xpRpsP1 + "/" + _nextLevelRpsP1 + ")";
		_guiP2.text = "Lives: " + _livesP2 + " | Ammo: " + _ammoP2 +
		" \nSpeed LV" + _levelSpeedP2 + " (XP: " + _xpSpeedP2 + "/" + _nextLevelSpeedP2 + 
		") - Fire Rate LV" + _levelRpsP2 + " (XP: " + _xpRpsP2 + "/" + _nextLevelRpsP2 + ")";
	}

	// Reset GUI stats
	public void GUIReset (string ship)
	{
		if (ship == "ShipP1")
		{
			_weaponFireP1.specialWeapon.ammo = 0;
			_xpCollectionP1.xpSpeed = 0;
			_xpCollectionP1.xpRps = 0;
			_xpCollectionP1.nextLevelSpeed = 1;
			_xpCollectionP1.nextLevelRps = 1;
			_xpCollectionP1.levelSpeed = 1;
			_xpCollectionP1.levelRps = 1;
			//Debug.Log("P1 Reset check...");
		}

		else if (ship == "ShipP2")
		{
			_weaponFireP2.specialWeapon.ammo = 0;
			_xpCollectionP2.xpSpeed = 0;
			_xpCollectionP2.xpRps = 0;
			_xpCollectionP2.nextLevelSpeed = 1;
			_xpCollectionP2.nextLevelRps = 1;
			_xpCollectionP2.levelSpeed = 1;
			_xpCollectionP2.levelRps = 1;
			//Debug.Log("P2 Reset check...");
		}
	}
}