using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {

	private Text livesText;
	private Image lifeImage;
	private GameManager manager;
	[SerializeField]
	private Sprite athleteSprite;
	[SerializeField]
	private Sprite nerdSprite;
	[SerializeField]
	private Sprite procrastinatorSprite;

	// Use this for initialization
	void Start () {
		//Todo: grab the number of lives from the current game state, so that we may
		// display how many lives the player has left.
		manager = FindObjectOfType<GameManager>();
		livesText = GetComponentInChildren<Text> ();
		livesText.text = "x " + manager.getNumLives();
		lifeImage = GetComponentInChildren<Image> ();

		string lifeImageType = FindObjectOfType<player> ().GetType ().ToString ();

		switch (lifeImageType) {
		case "athlete":
			if (athleteSprite != null) {
				lifeImage.sprite = athleteSprite;
			} else {
				Debug.LogError ("Athlete sprite not assigned.");
			}
			break;
		case "nerd":
			if (nerdSprite != null) {
				lifeImage.sprite = nerdSprite;
			} else {
				Debug.LogError ("Nerd sprite not assigned.");
			}
			break;
		case "procrastinator":
			if (procrastinatorSprite != null) {
				lifeImage.sprite = procrastinatorSprite;
			} else {
				Debug.LogError ("Procrastinator sprite not assigned.");
			}
			break;
		default:
			Debug.LogError ("Player type not found.");
			break;
		}

	}
	
	public void updateLives(){
		livesText.text = "x " + manager.getNumLives ();
	}
}
