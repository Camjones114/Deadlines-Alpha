using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadUI : MonoBehaviour {

	[SerializeField]
	private Sprite athleteProfile;
	[SerializeField]
	private Sprite nerdProfile;
	[SerializeField]
	private Sprite procrastinatorProfile;

	// Use this for initialization
	void Start () {
		//the playerType looks in the scene for the player, and checks what type of player it is
		string playerType = FindObjectOfType<player>().GetType().ToString();

		switch (playerType) {
		case "athlete":
			setUItoAthlete ();
			break;
		case "nerd":
			setUItoNerd ();
			break;
		case "procrastinator":
			setUItoProcrastinator ();
			break;
		default:
			Debug.LogError ("Player type not found.");
			GetComponent<Image> ().color = new Color (0, 0, 0);
			break;
		}

	}


	void setUItoAthlete(){
		GetComponent<Image>().color = new Color(0,255,0);
		if (athleteProfile != null) {
			GameObject.Find ("playerImage").GetComponent<Image> ().sprite = athleteProfile;
		} else {
			Debug.LogError ("No athlete profile assigned.");
		}

		Component[] uiText = GetComponentsInChildren<Text> ();
		foreach (Text ui in uiText) {
			ui.color = new Color (255, 255, 255);
		}
	}

	void setUItoNerd(){
		GetComponent<Image> ().color = new Color (255, 0, 0);
		if (nerdProfile != null) {
			GameObject.Find ("playerImage").GetComponent<Image>().sprite = nerdProfile;
		} else {
			Debug.LogError ("No nerd profile assigned.");
		}
		Component[] uiText = GetComponentsInChildren<Text> ();
		foreach (Text ui in uiText) {
			ui.color = new Color (255, 255, 255);
		}
	}

	void setUItoProcrastinator(){
		GetComponent<Image> ().color = new Color (0, 0, 255);
		if (procrastinatorProfile != null) {
			GameObject.Find ("playerImage").GetComponent<Image>().sprite = procrastinatorProfile;
		} else {
			Debug.LogError ("No procrastinator profile assigned.");
		}
		Component[] uiText = GetComponentsInChildren<Text> ();
		foreach (Text ui in uiText) {
			ui.color = new Color (255, 255, 255);
		}
	}
}
