using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour {

	private Image timerImage;
	[SerializeField]
	private float timerLength;
	[SerializeField]
	private float remainingTime;

	[SerializeField]
	private Sprite alarm1;
	[SerializeField]
	private Sprite alarm2;
	[SerializeField]
	private Sprite alarm3;
	[SerializeField]
	private Sprite alarm4;
	[SerializeField]
	private Sprite alarm5;
	[SerializeField]
	private Sprite alarm6;


	// Use this for initialization
	void Start () {
		timerImage = GetComponent<Image> ();
		timerImage.sprite = alarm1;
		if (timerLength <= 0) {
			timerLength = 15.0f;
			remainingTime = timerLength;
		}
	}
	
	// Update is called once per frame
	void Update () {
		remainingTime -= Time.deltaTime;
		bool alarm2Set = false;
		bool alarm3Set = false;
		bool alarm4Set = false;
		bool alarm5Set = false;
		bool alarm6Set = false;
		if (!alarm2Set && (remainingTime / timerLength <= 0.8)) {
			timerImage.sprite = alarm2;
			alarm2Set = true;
		}
		if (!alarm3Set && (remainingTime / timerLength <= 0.6)) {
			timerImage.sprite = alarm3;
			alarm3Set = true;
		}
		if (!alarm4Set && (remainingTime / timerLength <= 0.4)) {
			timerImage.sprite = alarm4;
			alarm4Set = true;
		}
		if (!alarm5Set && (remainingTime / timerLength <= 0.25)) {
			timerImage.sprite = alarm5;
			alarm5Set = true;
		}
		if (!alarm6Set && (remainingTime / timerLength <= 0.1)) {
			timerImage.sprite = alarm6;
			alarm6Set = true;
		}

		if (remainingTime <= 0) {
			FindObjectOfType<GameManager> ();
		}

	}

	public void setTimer(float timeAmount){
		timerLength = timeAmount;
		remainingTime = timerLength;
		Debug.Log (timerLength + " is the amount of time we have");
	}
}
