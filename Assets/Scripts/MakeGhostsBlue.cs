using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGhostsBlue : MonoBehaviour {

	public float duration;

	GhostScript ghost;

	public GameObject pickupEffect;
	public GameObject powerUpCube;

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			StartCoroutine( Pickup (other) );
			//powerUpCube.SetActive(false);

		}
	}

	IEnumerator Pickup(Collider player)
	{
		Instantiate (pickupEffect, transform.position, transform.rotation);

		GetComponent<MeshRenderer> ().enabled = false;
		GetComponent<Collider> ().enabled = false;

		ghost = GameObject.Find ("GhostRed").GetComponent<GhostScript> ();
		ghost.makeGhostBlue ();
		ghost = GameObject.Find ("GhostYellow").GetComponent<GhostScript> ();
		ghost.makeGhostBlue ();
		ghost = GameObject.Find ("GhostGreen").GetComponent<GhostScript> ();
		ghost.makeGhostBlue ();
		ghost = GameObject.Find ("GhostCyan").GetComponent<GhostScript> ();
		ghost.makeGhostBlue ();

		yield return new WaitForSeconds (duration);

		ghost = GameObject.Find ("GhostRed").GetComponent<GhostScript> ();
		ghost.getDefaultColorback ();
		ghost = GameObject.Find ("GhostYellow").GetComponent<GhostScript> ();
		ghost.getDefaultColorback ();
		ghost = GameObject.Find ("GhostGreen").GetComponent<GhostScript> ();
		ghost.getDefaultColorback ();
		ghost = GameObject.Find ("GhostCyan").GetComponent<GhostScript> ();
		ghost.getDefaultColorback ();

		Destroy (gameObject);
	}
}