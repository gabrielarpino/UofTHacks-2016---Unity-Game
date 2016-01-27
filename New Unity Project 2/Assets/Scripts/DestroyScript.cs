using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {
	
	private float destroyTime = 10f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
	
	}
	
	// Update is called once per frame

}
