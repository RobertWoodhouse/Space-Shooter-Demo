using UnityEngine;
using System.Collections;

[System.Serializable]
public class PrimaryWeapon : System.Object
{
	//Projectile settings
	public float 		projectileSpeed = 300.0f;
	public float 		fireRate = 0.5f;
	public float 		nextFire = 0.0f;
}

[System.Serializable]
public class SpecialWeapon : System.Object 
{
	//Projectile settings
	public float 		projectileSpeed = 300.0f;
	public float 		fireRate = 0.5f;
	public float 		nextFire = 0.0f;
	public int 			ammo = 0;
}

public class WeaponFire : MonoBehaviour 
{
	public Transform 			projectileSpawn;

	//Weapon Prefabs
	public Rigidbody2D 			projectilePrefab;
	public Rigidbody2D 			misslePrefab;
	public Rigidbody2D 			laserPrefab;

	public int 					ammoMissle = 5;
	public float 				speedMissle = 250.0f;
	public float 				fireRateMissle = 0.35f;

	public int 					ammoLaser = 4;
	public float 				speedLaser = 400.0f;
	public float 				fireRateLaser = 0.7f;

	public PrimaryWeapon 		primaryWeapon;
	public SpecialWeapon 		specialWeapon;

	private Rigidbody2D 		_selectedWeapon;
	private Rigidbody2D 		_projectileClone; // Single shot

	void Awake () 
	{
		_selectedWeapon = null;
	}
	
	void Update () 
	{
		ShootDebug();	
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		// Equips weapons and sets their stats
		if (coll.tag == "CollectableMissle")
		{
			_selectedWeapon = misslePrefab;
			specialWeapon.ammo = ammoMissle;
			specialWeapon.projectileSpeed = speedMissle;
			specialWeapon.fireRate = fireRateMissle;
			//Debug.Log("Homing missle equipped");
		}

		if (coll.tag == "CollectableLaser")
		{
			_selectedWeapon = laserPrefab;
			specialWeapon.ammo = ammoLaser;
			specialWeapon.projectileSpeed = speedLaser;
			specialWeapon.fireRate = fireRateLaser;
			//Debug.Log("Laser equipped");
		}
	}

	// Fire gun on PC/Mac
	void ShootDebug ()
	{	
		if (gameObject.tag == "ShipP1")
		{	
			// Primary Weapon
			if (Input.GetKey(KeyCode.Space) && Time.time > primaryWeapon.nextFire)
			{
				primaryWeapon.nextFire = Time.time + primaryWeapon.fireRate;
				_projectileClone = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation) as Rigidbody2D;
				_projectileClone.AddForce(projectileSpawn.transform.up * primaryWeapon.projectileSpeed);
				GetComponent<AudioSource>().Play();
			}

			// Special Weapon
			if (Input.GetKey(KeyCode.C) && Time.time > specialWeapon.nextFire)
			{
				if (_selectedWeapon == null || specialWeapon.ammo <= 0)
				{
					//Debug.Log("No weapon equiped / No ammo");
					_selectedWeapon = null;
					specialWeapon.projectileSpeed = 300.0f;
					specialWeapon.fireRate = 0.5f;
				}

				else
				{	
					specialWeapon.nextFire = Time.time + specialWeapon.fireRate;
					_projectileClone = Instantiate(_selectedWeapon, projectileSpawn.position, projectileSpawn.rotation) as Rigidbody2D;
					_projectileClone.AddForce(projectileSpawn.transform.up * specialWeapon.projectileSpeed);
					specialWeapon.ammo--;
				}
			}
		}

		if (gameObject.tag == "ShipP2")
		{	
			// Primary Weapon
			if (Input.GetKey(KeyCode.RightAlt) && Time.time > primaryWeapon.nextFire)
			{
				primaryWeapon.nextFire = Time.time + primaryWeapon.fireRate;
				_projectileClone = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation) as Rigidbody2D;
				_projectileClone.AddForce(projectileSpawn.transform.up * primaryWeapon.projectileSpeed);
				GetComponent<AudioSource>().Play();
			}

			// Special Weapon
			if (Input.GetKey(KeyCode.RightShift) && Time.time > specialWeapon.nextFire)
			{
				if (_selectedWeapon == null || specialWeapon.ammo <= 0)
				{
					//Debug.Log("No weapon equiped / No ammo");
					_selectedWeapon = null;
					specialWeapon.projectileSpeed = 300.0f;
					specialWeapon.fireRate = 0.5f;
				}

				else
				{	
					specialWeapon.nextFire = Time.time + specialWeapon.fireRate;
					_projectileClone = Instantiate(_selectedWeapon, projectileSpawn.position, projectileSpawn.rotation) as Rigidbody2D;
					_projectileClone.AddForce(projectileSpawn.transform.up * specialWeapon.projectileSpeed);
					specialWeapon.ammo--;
				}
			}
		}
	}

	// TODO: Fire gun on Consoles
	void Shoot ()
	{

	}
}