﻿using System.Collections;
using UnityEngine;

public class BackgroundmusicController : MonoBehaviour {

	void Awake ()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("music");
		if (objs.Length > 1)
			Destroy (this.gameObject);

		DontDestroyOnLoad (this.gameObject);
	}
}