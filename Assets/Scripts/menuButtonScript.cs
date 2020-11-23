using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtonScript : MonoBehaviour {

	public void GoBackToMainMenu ()
	{
		SceneManager.LoadScene (0);
	}
}
