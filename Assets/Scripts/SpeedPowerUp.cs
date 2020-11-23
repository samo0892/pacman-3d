using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour {

	public float multiplier = 2f;
	public float duration;

	public GameObject powerUpCube;
	public GameObject pickupEffect;

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

		PacmanController stats = player.GetComponent<PacmanController> ();
		stats.MovementSpeed *= multiplier;

		GetComponent<MeshRenderer> ().enabled = false;
		GetComponent<Collider> ().enabled = false;

		powerUpCube.SetActive(false);

		yield return new WaitForSeconds (duration);

		//stats.MovementSpeed /= multiplier;

		Destroy (gameObject);
	}
}
