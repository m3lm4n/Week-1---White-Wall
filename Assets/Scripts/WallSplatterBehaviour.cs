using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSplatterBehaviour : MonoBehaviour {

	public GameObject splatterPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision collision) {
		RaycastHit hit = ((BulletBehaviour) collision.gameObject.GetComponent(typeof(BulletBehaviour))).previousRaycastHit;
		Destroy (collision.gameObject);

		GameObject splatter = Instantiate (splatterPrefab, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));
		splatter.transform.position = splatter.transform.position + 0.01f * hit.normal;
		splatter.transform.Rotate (hit.normal, Random.value * 360, Space.World);
		Debug.DrawRay (splatter.transform.position, hit.normal, Color.red, 10);
	}
}
