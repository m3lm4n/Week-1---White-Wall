using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

	public GameObject splatterPrefab;

	public RaycastHit previousRaycastHit;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate() {
		RaycastHit hit;
		if (Physics.Raycast (GetComponent<Collider> ().transform.position,  GetComponent<Rigidbody>().velocity, out hit, 10, LayerMask.GetMask ("Wall"))) {
			previousRaycastHit = hit;
		}
	}
}
