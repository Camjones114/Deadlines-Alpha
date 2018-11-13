using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	[SerializeField]
	private float movementspeed;
	[SerializeField]
	private float jumpheight;
	[SerializeField]
	private bool grounded = true;
	private bool facing = true;
	private float horizontal;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
	}

	public float getMovementspeed(){
		return movementspeed;
	}

	public float getJumpheight(){
		return jumpheight;
	}

	public void setMovementspeed(float ms){
		movementspeed = ms;
	}

	public void setJumpheight(float jh){
		jumpheight = jh;		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		string newTag = collision.collider.tag;
		if (newTag == "Ground")
		{
			grounded = true;
		}
	}

	//Todo: Create a fix for when the player walks off of a platform so they can not jump mid-air
	void OnCollisionExit2D(Collision2D collision){
		string newTag = collision.collider.tag;
		if (newTag == "Ground") {
			//grounded = false;
		}
	}

	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxis("Horizontal");
		myRigidBody.velocity = new Vector2(horizontal * movementspeed, myRigidBody.velocity.y);
		if (Input.GetKeyDown(KeyCode.Space) && grounded) {
			myRigidBody.AddForce(transform.up * jumpheight, ForceMode2D.Impulse);
			grounded = false;
		}
		if (horizontal > 0 && !facing) {
			Flip();
		}
		else if(horizontal < 0 && facing)
		{
			Flip();
		}
	}

	private void Flip()
	{
		facing = !facing;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}