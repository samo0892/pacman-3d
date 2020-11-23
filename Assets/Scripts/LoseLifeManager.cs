using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLifeManager : MonoBehaviour {

	int countLife = 3;

	void Start () {
		DontDestroyOnLoad (gameObject);
	}

	void Update () {

	}

	public void setLifeCounter(int lifes){
		countLife = lifes;
	}

	public int getLifesCounter() {
		return countLife;
	}
}