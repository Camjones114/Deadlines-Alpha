using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

	[SerializeField]
	private int maxHealth;
	private int health;
	public Text healthText;
	private bool updateHealth;
	private GameObject character;
	[SerializeField]
	private RectTransform healthBar;

	void Start(){
		character = GameObject.FindGameObjectWithTag ("Player");

		maxHealth = character.GetComponent<player>().getHealth();
		health = maxHealth;
		healthText = GetComponent<Text> ();
		healthText.text = "Health : " + health;
		updateHealth = false;
		if(healthBar == null){
			Debug.Log ("Status indicator: No health bar referenced.");
		}
	}

	//update the health based on an increase or decrease 
	void recoverHealth(int amount){
		health += amount;
		if (health > maxHealth) {
			health = maxHealth;
		}
		updateHealth = true;
	}

	void takeDamage(int amount){
		health -= amount;
		if (health <= 0) {
			health = 0;
		}
		updateHealth = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			takeDamage (1);
		} else if (Input.GetKeyDown (KeyCode.T)) {
			recoverHealth (1);
		}

		if (updateHealth) {
			healthText.text = "Health : " + health;
			float value = (float) health / (float) maxHealth;
			healthBar.localScale = (new Vector3 (value, 1f, 1f));
		}

	}
}
