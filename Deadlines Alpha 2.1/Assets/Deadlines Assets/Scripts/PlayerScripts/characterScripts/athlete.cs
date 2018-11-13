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
		health = 4;
		damage = 3;
		setAttackDuration(0.4f);
	}

	public void attack(){
		
	}

}
