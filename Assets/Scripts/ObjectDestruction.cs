using UnityEngine;
using System.Collections;

public class ObjectDestruction : MonoBehaviour 
{
	public float 		lifeSpan = 1.0f;

	void Start ()
	{
		Destroy (gameObject, lifeSpan);
	}
}
