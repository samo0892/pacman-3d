using System.Collections;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	public void ChangeToScene (int sceneToChange) {
		Application.LoadLevel (sceneToChange);
	}
}
