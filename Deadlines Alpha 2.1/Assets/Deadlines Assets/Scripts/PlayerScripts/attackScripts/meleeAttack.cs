using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : Attack {

	[SerializeField]
	private EdgeCollider2D hitBox;

	public meleeAttack (){
		
	}

	// Use this for initialization
	void Start () {
		hitBox = gameObject.GetComponent<EdgeCollider2D> ();
		//safety net to make sure our weapon is a trigger
		if(!hitBox.isTrigger){ 
			hitBox.isTrigger = true;
		}
		hitBox.enabled = false;
	}

	public void attack(float duration){
		//Todo: set the animator to melee attack, enable the hitBox,
		// then disable it after the animation is over.
		//hitBox.enabled = true;
		//Here is where the logic for the state machine will go
		Debug.Log("Attacking!!!\n");
		StartCoroutine(animationTime());
		//yield animationTime;
		//The animation should be over at this point
		//hitBox.enabled = false;
	}

	IEnumerator animationTime(){
		Debug.Log ("starting wait");
		hitBox.enabled = true;
		yield return new WaitForSeconds (1);
		hitBox.enabled = false;
		Debug.Log ("ending wait");
	}

	void onTriggerEnter2D(Collider2D col){
		if (col.tag == "enemy") {
			//Todo: send signal to enemy that they should take damage.
			// It should look something like this:
			//other.GetComponent<"health">().takeDamage();
			col.SendMessage("", 0);
		}
	}
}