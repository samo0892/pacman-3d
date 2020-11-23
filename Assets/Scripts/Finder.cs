using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Finder : MonoBehaviour {

	public Transform destinationPoint;

	public void Update() {
		transform.GetComponent<NavMeshAgent> ().destination = destinationPoint.position;
	}
}
