using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public int damage;
	public int health;
	public PlayerMovement movement;
	public Attack attack;
	public float attackDuration;

	void Start(){
		movement = gameObject.GetComponent<PlayerMovement> ();
		attack = gameObject.GetComponent<Attack> ();
	}

	public void setHealth(int health){
		this.health = health;
	}

	public int getHealth(){
		return health;
	}

	public void setDamage(int damage){
		this.damage = damage;
	}

	public int getDamage(){
		return damage;
	}

	public void setAttackDuration(float attackDuration){
		this.attackDuration = attackDuration;
	}

	public float getAttackDuration(){
		return attackDuration;
	}

}
