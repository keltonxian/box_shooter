using UnityEngine;
using System.Collections;

public class SpawnGameObjectsPopup : MonoBehaviour {

	// public variables
	public float secondsBetweenSpawning = 0.1f;
	public float xAbsMinRange = 4.0f;
	public float xAbsMaxRange = 6.0f;
	public float yAbsMinRange = 0.0f;
	public float yAbsMaxRange = 1.0f;
	public float zAbsMinRange = 4.0f;
	public float zAbsMaxRange = 6.0f;
	public GameObject[] spawnObjects; // what prefabs to spawn

	private float nextSpawnTime;

	// Use this for initialization
	void Start ()
	{
		// determine when to spawn the next object
		nextSpawnTime = Time.time+secondsBetweenSpawning;
	}

	// Update is called once per frame
	void Update ()
	{
		// exit if there is a game manager and the game is over
		if (GameManager.gm) {
			if (GameManager.gm.gameIsOver)
				return;
		}

		// if time to spawn a new game object
		if (Time.time  >= nextSpawnTime) {
			// Spawn the game object through function below
			MakeThingToSpawn ();

			// determine the next time to spawn the object
			nextSpawnTime = Time.time+secondsBetweenSpawning;
		}	
	}

	void MakeThingToSpawn ()
	{
		Vector3 spawnPosition;

		// get a random position between the specified ranges
		spawnPosition.x = Random.Range (0, xAbsMaxRange);
		spawnPosition.y = Random.Range (yAbsMinRange, yAbsMaxRange);
		spawnPosition.z = Random.Range (0, zAbsMaxRange);
		if (spawnPosition.x < xAbsMinRange && spawnPosition.z < zAbsMinRange) {
			return;
		}
		float t1 = Random.Range (-1, 1);
		float t2 = Random.Range (-1, 1);
		if (t1 < 0) {
			spawnPosition.x *= -1;
		}
		if (t2 < 0) {
			spawnPosition.z *= -1;
		}

		// determine which object to spawn
		int objectToSpawn = Random.Range (0, spawnObjects.Length);

		// actually spawn the game object
		GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;

		// make the parent the spawner so hierarchy doesn't get super messy
		spawnedObject.transform.parent = gameObject.transform;
	}
}
