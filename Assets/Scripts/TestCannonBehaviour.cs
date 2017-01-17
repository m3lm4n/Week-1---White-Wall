using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCannonBehaviour : MonoBehaviour {

	public GameObject bulletPrefab;
	public bool repeat = true;
	public int frequency = 60;
	public int thrust = 5000;

	private float timeSinceLastBullet;
	private float bulletInterval;

	// Use this for initialization
	void Start () {
		if (!repeat) {
			fireBullet ();
		}
		bulletInterval = 1f / frequency;
		timeSinceLastBullet = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (repeat) {
			timeSinceLastBullet += Time.deltaTime;

			if (timeSinceLastBullet > bulletInterval) {
				fireBullet ();
				timeSinceLastBullet = 0;
			}
		}
	}

	void fireBullet() {
		GameObject newBullet = Instantiate (bulletPrefab);
		newBullet.GetComponent<Rigidbody> ().AddForce (transform.forward * thrust);
		newBullet.transform.position = transform.position;
	}
}
