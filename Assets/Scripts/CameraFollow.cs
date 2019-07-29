using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public float 		xMargin = 1.0f;
	public float 		yMargin = 1.0f;
	public float 		xSmooth = 10.0f;
	public float 		ySmooth = 10.0f;
	public Vector2 		maxXAndY;
	public Vector2 		minXAndY;
	public Transform 	cameraFocusPrefab;

	void Awake ()
	{
		cameraFocusPrefab = GameObject.Find("CameraFocus").transform;
	}

	void FixedUpdate ()
	{
		CamFocusTracker();
	}

	bool CheckXMargin ()
	{
		return Mathf.Abs (transform.position.x - cameraFocusPrefab.position.x) > xMargin;
	}

	bool CheckYMargin ()
	{
		return Mathf.Abs (transform.position.y - cameraFocusPrefab.position.y) > yMargin;
	}

	void CamFocusTracker ()
	{
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		if(CheckXMargin())
		{
			targetX = Mathf.Lerp (transform.position.x, cameraFocusPrefab.position.x, xSmooth * Time.deltaTime);
		}

		if(CheckYMargin())
		{
			targetY = Mathf.Lerp (transform.position.y, cameraFocusPrefab.position.y, ySmooth * Time.deltaTime);
		}

		// Clamping between 2 values
		targetX = Mathf.Clamp (targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp (targetY, minXAndY.y, maxXAndY.y);

		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
