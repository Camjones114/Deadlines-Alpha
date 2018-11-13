using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class averageStudent : player {

	public averageStudent(){
		health = 4;
		damage = 3;
	}

	public void Start(){
		movement.setMovementspeed(6f);
		movement.setJumpheight (13f);
	}

	public void attack(){
		
	}
}
