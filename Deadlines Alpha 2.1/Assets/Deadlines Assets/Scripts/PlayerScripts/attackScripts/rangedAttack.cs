using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedAttack : MonoBehaviour {

	private GameObject projectile;

	[SerializeField]
	private GameObject Player;
	private Rigidbody2D projInstance;

	// Use this for initialization
	void Start () {
		
	}
	
	public void attack(){
		//Todo: set the animator to range attack, and instantiate a bullet

		//Here is where the logic for the state machine will go
		Debug.Log("Ranged Attacking!!!");
		//The animation should be over at this point

	}
}
