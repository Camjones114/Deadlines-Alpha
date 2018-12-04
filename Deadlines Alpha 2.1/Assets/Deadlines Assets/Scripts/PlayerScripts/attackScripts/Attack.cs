using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	[SerializeField]
	private bool attacking;
	public float attackDuration;
	[SerializeField]
	private float attackTimer;

	[SerializeField]
	private bool attackReady;
	[SerializeField]
	private int attackType;
	private meleeAttack meleeAtk;
	private rangedAttack rangedAtk;

	float getAttackDurationFromPlayer(){
		player athlete = gameObject.GetComponent<athlete> ();
		player nerd = gameObject.GetComponent<nerd> ();
		player procrastinator = gameObject.GetComponent<procrastinator> ();

		if (athlete != null) {
			Debug.Log ("Returning player type athlete");
			Debug.Log (athlete.getAttackDuration());
			return athlete.getAttackDuration ();
		} else if (nerd != null) {
			Debug.Log ("Returning player type nerd");
			return nerd.getAttackDuration ();
		} else if (procrastinator != null) {
			Debug.Log ("Returning player type procrastinator");
			return procrastinator.getAttackDuration ();
		} else {
			Debug.LogError ("No character class found by attack class.");
			return 1;
		}
	}

	// Use this for initialization
	void Start () {
		attacking = false;
		attackDuration = getAttackDurationFromPlayer();
		attackType = setAttackType();
		attackReady = true;
	}

	void Update(){
		if(attackReady) {
			//then you can attack
			if(Input.GetKey(KeyCode.Mouse0)){
				if (attackType == 0) {
					if (meleeAtk == null) {
						meleeAtk = gameObject.GetComponent<meleeAttack> ();
					}
					meleeAtk.attack (attackDuration);
					attackReady = false;
				} else if (attackType == 1) {
					rangedAtk.attack ();
					attackReady = false;
				} else {
					Debug.LogError ("This character doesn't have an attack, oh nooooo");
				}
			}
			attackTimer = attackDuration;
		} else {
			attackTimer -= Time.deltaTime;
			if (attackTimer <= 0) {
				attackReady = true;
			}
		}
	}

	private int setAttackType(){
		this.meleeAtk = gameObject.GetComponent<meleeAttack> ();
		this.rangedAtk = gameObject.GetComponent<rangedAttack> ();
		if (meleeAtk != null && rangedAtk == null) {
			return 0;
		} else if (meleeAtk == null && rangedAtk != null) {
			return 1;
		} else {
			//type not found, or both types are applied
			return -1;
		}
	}
}