using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private player character;
	[SerializeField]
	private int numLives;
	private int score;
	private int coinCount;
	private int healthAmt;

	[SerializeField]
	private float timeForTimer;
	private Scene level;

	// Use this for initialization
	void Start () {
		character = FindObjectOfType<player> ();
		if (character == null) {
			Debug.LogWarning ("Character not found.");
			character = FindObjectOfType<player> ();
		}
		healthAmt = character.getHealth ();
		//Todo: Find out how to save the scene of the level that was created procedurally,
		// so that it may be loaded upon death.

		FindObjectOfType<TimerDisplay>().setTimer(getTimeForLevel ());
	}
	
	// Update is called once per frame
	void Update () {
		
		if (healthAmt < 0) {
			decrementLives ();
		}

		if (coinCount > 9) {
			incrementLives ();
			coinCount -= 10;
		}

		if (numLives < 0) {
			SceneManager.LoadScene ("GameOver");
		}

	}

	float getTimeForLevel(){
		string playerType = FindObjectOfType<player> ().GetType ().ToString ();
		switch (playerType) {
		case "athlete":
			return 270.0f;
			break;
		case "nerd":
			return 330.0f;
			break;
		case "procrastinator":
			return 300.0f;
			break;
		default:
			Debug.LogError ("Player type not found, setting default time.");
			return 1000.0f;
			break;
		}
	}

	void decrementLives(){
		numLives--;
		FindObjectOfType<LivesDisplay> ().updateLives ();
	}

	void incrementLives(){
		numLives++;
		FindObjectOfType<LivesDisplay> ().updateLives ();
	}

	public int getNumLives(){
		return numLives;
	}
}
