using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

	private float destroyTime = 7.0f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
	
	}
	
	// Update is called once per frame

}
