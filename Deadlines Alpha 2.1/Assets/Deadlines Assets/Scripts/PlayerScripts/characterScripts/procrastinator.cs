using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procrastinator : player {

	public procrastinator(){
		health = 6;
		damage = 2;
	}

	public void Start(){
		movement.setMovementspeed(7f);
		movement.setJumpheight (13f);
	}

	public void attack(){

	}
}
