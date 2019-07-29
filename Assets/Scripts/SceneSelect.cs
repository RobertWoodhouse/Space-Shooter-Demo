using UnityEngine;
using System.Collections;

public class SceneSelect : MonoBehaviour 
{
	public static SceneSelect 		S;
	
	void Start () 
	{
		S = this;
	}
	
	// Select scenes e.g. Main Menu and Restart for GameOver
	public static void Scenes (int scene) 
	{
		switch (scene)
		{
			case 1:
				// TODO: Add main menu
				Application.LoadLevel ("MainMenu");
				break;
			case 2:
				Application.LoadLevel ("VS_Scene");
				break;
			case 3:
				Application.Quit();
				break;
			default:
				Debug.Log ("Scene non-existent");
				break;
		}
	}
}