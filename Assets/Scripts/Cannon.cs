using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public GameObject bulletPrefab;
	public bool repeat = true;
	public int frequency = 60;
	public int thrust = 5000;

	private float timeSinceLastBullet;
	private float bulletInterval;

	public bool isFiring;

	// Use this for initialization
	void Start () {
		isFiring = false;

		bulletInterval = 1f / frequency;
		timeSinceLastBullet = 0;
	}

	// Update is called once per frame
	void Update () {
		if (isFiring) {
			timeSinceLastBullet += Time.deltaTime;

			if (timeSinceLastBullet > bulletInterval) {
				Fire ();
				timeSinceLastBullet = 0;
			}
		}
	}

	public void Fire() {
		GameObject newBullet = Instantiate (bulletPrefab);
		newBullet.GetComponent<Rigidbody> ().AddForce (transform.forward * thrust);
		newBullet.transform.position = transform.position;
	}

	public void StartFiring() {
		isFiring = true;
	}
}
