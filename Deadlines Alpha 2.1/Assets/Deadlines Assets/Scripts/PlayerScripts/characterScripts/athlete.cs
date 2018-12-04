using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class athlete : player {

	public athlete(){
		//Todo: create parameters for athlete specific variables
	}

	public void Start(){
		movement.setMovementspeed(8f);
		movement.setJumpheight (14f);
		setHealth(4);
		setDamage(3);
		setAttackDuration(0.4f);
		setLives(3);
	}

	public void attack(){
		
	}

}
