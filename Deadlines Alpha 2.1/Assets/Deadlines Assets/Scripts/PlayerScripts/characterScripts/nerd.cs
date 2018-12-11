using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nerd : player {

	public nerd(){
		
	}

	public void Start(){
		movement.setMovementspeed(6f);
		movement.setJumpheight (13f);
		setHealth(3);
		setDamage(2);
		setAttackDuration (0.4f);
		setLives (5);
	}

	public void attack(){

	}
}
