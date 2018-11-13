using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

	[SerializeField]
	private int health;
	public Text healthText;
	private GameObject character;

	void Start(){
		character = GameObject.FindGameObjectWithTag ("player");
		health = character.GetComponent<player>().getHealth();
		Debug.Log (health);
	}

	//update the health based on an increase or decrease 
	void changeHealth(int amount){
		health += amount;
	}
	
	// Update is called once per frame
	void Update () {
		//healthText.text = "Health : ";
	}
}
