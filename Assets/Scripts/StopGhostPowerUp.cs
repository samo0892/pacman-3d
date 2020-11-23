using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGhostPowerUp : MonoBehaviour {

	public float duration;

	GhostScript ghost;

	public GameObject pickupEffect;
	public GameObject powerUpCube;

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			StartCoroutine( Pickup (other) );

		}
	}

	IEnumerator Pickup(Collider player)
	{
		Instantiate (pickupEffect, transform.position, transform.rotation);

		GetComponent<MeshRenderer> ().enabled = false;
		GetComponent<Collider> ().enabled = false;

		ghost = GameObject.Find ("GhostRed").GetComponent<GhostScript> ();
		ghost.makeGhostSlow();
		ghost = GameObject.Find ("GhostYellow").GetComponent<GhostScript> ();
		ghost.makeGhostSlow();
		ghost = GameObject.Find ("GhostGreen").GetComponent<GhostScript> ();
		ghost.makeGhostSlow();
		ghost = GameObject.Find ("GhostCyan").GetComponent<GhostScript> ();
		ghost.makeGhostSlow();

		yield return new WaitForSeconds (duration);
	
		ghost = GameObject.Find ("GhostRed").GetComponent<GhostScript> ();
		ghost.makeGhostFast ();
		ghost = GameObject.Find ("GhostYellow").GetComponent<GhostScript> ();
		ghost.makeGhostFast ();
		ghost = GameObject.Find ("GhostGreen").GetComponent<GhostScript> ();
		ghost.makeGhostFast ();
		ghost = GameObject.Find ("GhostCyan").GetComponent<GhostScript> ();
		ghost.makeGhostFast ();

		//powerUpCube.SetActive (false);


		Destroy (gameObject);


	}
}