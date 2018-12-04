using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procrastinator : player {

	public procrastinator(){
		
	}

	public void Start(){
		movement.setMovementspeed(7f);
		movement.setJumpheight (13f);
		setHealth(3);
		setDamage(2);
		setAttackDuration (0.4f);
		setLives (4);
	}

	public void attack(){

	}
}
