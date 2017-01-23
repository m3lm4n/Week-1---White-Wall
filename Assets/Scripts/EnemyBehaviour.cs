using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject target;
	public float range;

	private NavMeshAgent agent;
	private Cannon cannon;
	private Transform cannonHorizontalTransform;

	private float rotationSpeed = 0.1f;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.destination = target.transform.position;

		cannon = GetComponentsInChildren<Cannon> ()[0];

		cannonHorizontalTransform = transform.Find ("CannonTransform");
	}

	void Update () {
		
	}

	void FixedUpdate() {
		if (cannon.isFiring) {
			cannonHorizontalTransform.rotation = GetRotationToTarget ();
		}

		if (GetDistanceToTarget () < range && !cannon.isFiring) {
			agent.Stop ();
			cannon.StartFiring ();
		}
	}

	float GetDistanceToTarget() {
		return Vector3.Distance(target.transform.position, transform.position);
	}

	public void acquireTarget(GameObject newTarget) {
		target = newTarget;
	}

	Quaternion GetRotationToTarget() {
		return Quaternion.LookRotation (target.transform.position - cannonHorizontalTransform.position, Vector3.up);
	}
}