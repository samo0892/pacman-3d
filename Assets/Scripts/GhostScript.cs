using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GhostScript : MonoBehaviour {

	public Transform[] target;

	public float speed = 10;
	public bool isblue;
	private int current;

	void Start() {
		isblue = false;
	}

	void Update(){
		if (transform.position != target [current].position) {
			Vector3 pos = Vector3.MoveTowards (transform.position, target [current].position, speed * Time.deltaTime);
			GetComponent<Rigidbody> ().MovePosition (pos);
		} else {
			current = (current + 1) % target.Length;
		}

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			StartCoroutine( Pickup (other) );
		}
	}
	public void makeGhostBlue() {
		
		if(CompareTag("REDGHOST") 
			|| CompareTag("YELLOWGHOST") 
			|| CompareTag("GREENGHOST")
			|| CompareTag("CYANGHOST")) {
			GetComponent<Renderer>().material.color = Color.blue;
			isblue = true;
		}
	}

	public void getDefaultColorback() {

		if(CompareTag("REDGHOST")) {
			GetComponent<Renderer>().material.color = Color.red;
		}
			
		if(CompareTag("YELLOWGHOST")) {
			GetComponent<Renderer>().material.color = Color.yellow;
		}

		if(CompareTag("GREENGHOST")) {
			GetComponent<Renderer>().material.color = Color.green;
		}

		if(CompareTag("CYANGHOST")) {
			GetComponent<Renderer>().material.color = Color.cyan;
		}
		isblue = false;
	}

	IEnumerator Pickup(Collider player)
	{
		//Instantiate (transform.position, transform.rotation);
		GetComponent<MeshRenderer> ().enabled = false;
		GetComponent<Collider> ().enabled = false;
		yield return new WaitForSeconds (5f);

		getDefaultColorback ();
		GetComponent<MeshRenderer> ().enabled = true;
		GetComponent<Collider> ().enabled = true;

	}

	public void makeGhostFast(){
		
		if(CompareTag("REDGHOST")) {
			speed = 10;
		}

		if(CompareTag("YELLOWGHOST")) {
			speed = 10;
		}

		if(CompareTag("GREENGHOST")) {
			speed = 10;
		}

		if(CompareTag("CYANGHOST")) {
			speed = 10;
		}
	}

	public void makeGhostSlow(){
		
		if(CompareTag("REDGHOST")) {
			speed = 0;
		}

		if(CompareTag("YELLOWGHOST")) {
			speed = 0;
		}

		if(CompareTag("GREENGHOST")) {
			speed = 0;
		}

		if(CompareTag("CYANGHOST")) {
			speed = 0;
		}
	}
}