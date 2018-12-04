using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

	[SerializeField]
	private int health;
	public Text healthText;
	private bool updateHealth;
	private GameObject character;

	void Start(){
		character = GameObject.FindGameObjectWithTag ("Player");
		health = character.GetComponent<player>().getHealth();
		healthText = GetComponent<Text> ();
		healthText.text = "Health : " + health;
		updateHealth = false;
	}

	//update the health based on an increase or decrease 
	void changeHealth(int amount){
		health += amount;
		updateHealth = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (updateHealth) {
			healthText.text = "Health : " + health;
		}

	}
}
