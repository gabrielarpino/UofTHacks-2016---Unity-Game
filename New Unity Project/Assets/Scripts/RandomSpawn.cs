using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {
	public Transform[] spawnPositions;
	public GameObject[] whatToSpawn;
	public float spawnTime = 4f;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnSomething", spawnTime, spawnTime);
	}
		
	void SpawnSomething() {
		int randomItem = Random.Range (0, whatToSpawn.Length);
		int randomLocation = Random.Range (0, spawnPositions.Length);
		Instantiate (whatToSpawn [randomItem], spawnPositions [randomLocation].transform.position, spawnPositions [randomLocation].transform.rotation);

	}
}
