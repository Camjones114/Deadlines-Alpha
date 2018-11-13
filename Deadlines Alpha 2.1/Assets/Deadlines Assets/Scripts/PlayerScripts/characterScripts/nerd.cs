using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nerd : player {

	public nerd(){
		health = 3;
		damage = 2;
	}

	public void Start(){
		movement.setMovementspeed(6f);
		movement.setJumpheight (12f);
	}

	public void attack(){

	}
}
