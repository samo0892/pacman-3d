using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour {

	public GameObject scoreUI;

	public string getScore() {
		return PlayerPrefs.GetString ("Score");
	}

	public void Start(){
		Debug.Log ("KLAPPT");
		Debug.Log (getScore ());
		scoreUI.GetComponent<Text> ().text = getScore ();
		//scoreUI.SetActive (true);
		//StartCoroutine (Wait (0.5f));
	}

	public IEnumerator Wait(float wait){
		yield return new WaitForSeconds (wait);

		yield return new WaitForSeconds (wait);
	}
}
