using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PacmanController : MonoBehaviour {

	//public AudioSource somesound;
	public float MovementSpeed = 0f;
	public int dots;

	private Animator animator = null;

	private int count;
	public Text countText;
	private int countLife;
	public Text lifesText;

	LoseLifeManager lifeManager;

	public AudioSource gameOverSound;

	private Vector3 up = Vector3.zero,
	right = new Vector3(0, 90, 0),
	down = new Vector3(0, 180, 0),
	left = new Vector3(0, 270, 0),
	currentDirection = Vector3.zero;

	private Vector3 initialPosition = Vector3.zero;

	GhostScript ghost;

	public void Reset() {
		transform.position = initialPosition;
		animator.SetBool("isDead", false);
		animator.SetBool("isMoving", false);
		currentDirection = down;
	}

	// Use this for initialization
	void Start () {

		lifeManager = GameObject.Find ("LifeManager").GetComponent<LoseLifeManager> ();
		QualitySettings.vSyncCount = 0;
		count = 0;
		countLife = lifeManager.getLifesCounter();
		SetCountText ();

		initialPosition = transform.position;
		animator = GetComponent<Animator>();
		ghost = GameObject.Find ("GhostRed").GetComponent<GhostScript> ();

		Reset();		
	}		

	// Update is called once per frame
	void Update () {
		var isMoving = true;

		if (Input.GetKey (KeyCode.UpArrow))
			currentDirection = up;
		else if (Input.GetKey (KeyCode.RightArrow))
			currentDirection = right;
		else if (Input.GetKey (KeyCode.DownArrow))
			currentDirection = down;
		else if (Input.GetKey (KeyCode.LeftArrow))
			currentDirection = left;
		else
			isMoving = false;

		//while (isMoving == false) 
		//{
		//	somesound.Play ();
		//}

		transform.localEulerAngles = currentDirection;
		animator.SetBool("isMoving", isMoving);

		if (isMoving) {
			transform.Translate (Vector3.forward * MovementSpeed * Time.deltaTime);
		} 

//		if (ghost.isblue == false) {
//			ghost.GetComponent<MeshRenderer> ().enabled = true;
//			ghost.GetComponent<Collider> ().enabled = true;
//		}
			
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Cube")) 
		{
			other.gameObject.GetComponent<Renderer> ().enabled = false;
			other.gameObject.GetComponent<Collider> ().enabled = false;
			AudioSource audio = other.gameObject.GetComponent<AudioSource> ();
			audio.Play ();
			Destroy (other.gameObject, audio.clip.length);

			//other.gameObject.SetActive (false);
			count += 100;
			dots--;
			Debug.Log ("Dots: " + dots);
			SetCountText ();
			Debug.Log ("CUBE COLLISION!");

		}

		if (other.gameObject.CompareTag ("GREENGHOST")
		    || other.gameObject.CompareTag ("REDGHOST")
		    || other.gameObject.CompareTag ("YELLOWGHOST")
		    || other.gameObject.CompareTag ("CYANGHOST")) {
			Debug.Log ("GHOST COLLISION!");
		

			if (ghost.isblue == true) {
//				ghost.GetComponent<MeshRenderer> ().enabled = false;
//				ghost.GetComponent<Collider> ().enabled = false;
				count += 100;
				SetCountText ();

			} else {

				if (lifeManager.getLifesCounter () > 0) {
					StartCoroutine (LoseLife ());
				}

				if (lifeManager.getLifesCounter () <= 0) {
					StartCoroutine (LoseGame ());
				}
			}
		}
	}

	void SetCountText()
	{
		lifesText.text = "LIFES: " + countLife.ToString ();
		countText.text = "SCORE: " + count.ToString ();

		//if (count >= 23500) 
		if (dots == 0)
		{
			PlayerPrefs.SetString ("Score", countText.text);
			//countText.text = "YOU WIN!";
			SceneManager.LoadScene(3);
		}
	}

	IEnumerator LoseLife()
	{
		PlayerPrefs.SetString ("Score", countText.text);
		gameOverSound.Play ();
		//countText.text = "YOU LOSE!";
		Time.timeScale = 0f;
		countLife--; 
		lifeManager.setLifeCounter (countLife);
		Debug.Log ("LOSE!");
		//gameOverSound.Play ();
		yield return new WaitWhile (()=> gameOverSound.isPlaying);
		SceneManager.LoadScene(1);

	}

	IEnumerator LoseGame(){
		PlayerPrefs.SetString ("Score", countText.text);
		gameOverSound.Play ();
		//countText.text = "GAME OVER!";
		Time.timeScale = 0f;
		lifeManager.setLifeCounter (3);
		Debug.Log ("GAME OVER!");
		yield return new WaitWhile (()=> gameOverSound.isPlaying);
		SceneManager.LoadScene(2);
	}
}