using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour {

	public int damage;
	public int health;
	public GameObject player;

	public EnemyMovement movement;



	// Use this for initialization
	void Start () {
		movement = gameObject.GetComponent<EnemyMovement> ();
		player = GameObject.FindGameObjectWithTag ("Player");

		//These would go in a specific enemy class, but these are for testing purposes.
		movement.setMovementspeed (4f);

		//These are the same for every enemy type, so they'll stay here.
		movement.calcRecDist(player.name);
		movement.setPlayerLoc (player.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
