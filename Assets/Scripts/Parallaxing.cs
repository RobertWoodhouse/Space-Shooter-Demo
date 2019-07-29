using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour 
{
	public Transform[] 		backgrounds; // Back/foregrounds to be parallaxed
	public float 			smoothing = 1.0f;

	private float[]			_parallaxScales;
	private Transform 		_cam;
	private Vector3 		_previousCamPos;

	void Awake ()
	{
		_cam = Camera.main.transform;
	}

	void Start () 
	{
		_previousCamPos = _cam.position;
		_parallaxScales = new float[backgrounds.Length];

		// Corresponding  Parallax Scales
		for (int i = 0; i < backgrounds.Length; i++)
		{
			_parallaxScales[i] = backgrounds[i].position.z * -1;
		}
	}
	
	void Update ()
	{
		for (int i = 0; i < backgrounds.Length; i++)
		{
			// The parallax is the opposite of the camera movement because the previous frame's multipled by the scale
			float parallax = (_previousCamPos.x - _cam.position.x) * _parallaxScales[i];

			// Set a target x position which is the current position plus the parallax
			var backgroundTargetPosX = backgrounds[i].position.x + parallax;

			// Create a target position which is the backgrounds current position with its target x position
			var backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			// Fade between current position and the target position using lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		_previousCamPos = _cam.position;
	}
}