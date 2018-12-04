using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Transform playerPos;

	private Rigidbody2D myRigidBody;
	private float movementspeed;
	private bool facing = true;
	private float horizontal;

	private float distFromPlayer;


	public void calcRecDist(string playerType){
		/* Gets the type of player from somewhere. The name of the object seems to make the most sense, as tag is already being
		 * used to identify what the player is in the basicEnemy script. These are tentative, to be finalized when the name
		 * of the player objects is finalized.
		 */

		if (playerType == "Nerd") {
			//Recommended distance is lower, because the Nerd has ranged attacks.
			distFromPlayer = 1f;
		}

		if (playerType == "Athlete") {
			//Recommended distance is higher, because the Athlete has mostly meelee attacks.
			distFromPlayer = 4f;
		}

		if (playerType == "Slacker") {
			//Not sure what the recommended distance for the slacker should be.
			distFromPlayer = 2f;
		}
	}


	public float getMovementspeed(){
		return movementspeed;
	}

	public void setMovementspeed(float ms){
		movementspeed = ms;
	}

	public void setPlayerLoc(Transform t){
		//How we figure out where the player is so we can go there.
		playerPos = t;
	}

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if (playerPos.position.x >= gameObject.transform.position.x) {
			horizontal = 1;
		} else {
			horizontal = -1;
		}

		myRigidBody.velocity = new Vector2(horizontal * movementspeed, myRigidBody.velocity.y);

		if (horizontal > 0){
			if (!facing){
				Flip();
			}
		}
		else if (horizontal < 0 ){
			if (facing){
				Flip();
			}
		}
	}

	private void Flip() {
		facing = !facing;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

