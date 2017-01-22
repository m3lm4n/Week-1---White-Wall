using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject target;
	public float spawnFrequency = 0.5f;

	private float timeSinceLastSpawn;
	private float spawnInterval;

	// Use this for initialization
	void Start () {
		spawnInterval = 1f / spawnFrequency;
		timeSinceLastSpawn = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpawn += Time.deltaTime;

		if (timeSinceLastSpawn > spawnInterval) {
			SpawnEnemy ();
			timeSinceLastSpawn = 0;
		}
	}

	void SpawnEnemy() {
		GameObject newEnemy = Instantiate (enemyPrefab);
		newEnemy.transform.position = transform.position;
		EnemyBehaviour enemy = newEnemy.GetComponent<EnemyBehaviour> ();
		enemy.acquireTarget (target);
	}
}
