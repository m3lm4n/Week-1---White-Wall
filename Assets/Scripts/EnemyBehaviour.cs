using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject target;
	public float range;

	private NavMeshAgent agent;
	private Cannon cannon;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.destination = target.transform.position;

		cannon = GetComponentsInChildren<Cannon> ()[0];
	}
	
	// Update is called once per frame
	void Update () {
		if (GetDistanceToTarget () < range) {
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
}