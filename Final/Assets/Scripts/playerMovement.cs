using UnityEngine;
using System.Collections;
using System;

public class playerMovement : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	public GameObject player;



	[SerializeField]
	private float maxSpeed = 5;
	[SerializeField]
	private float acceleration = 0.3f;
	[SerializeField]
	private float jumpForce = 5;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;


	private float currSpeed = 0;
	private bool isGround;
	private bool isJump;
	private float horizontal;


	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
	}

	private void TouchScreen(){

		//&& Input.GetTouch (0).phase == TouchPhase.Stationary
		if (Input.touchCount > 0 ) {
			Vector2 touchPosition = Input.GetTouch (0).position;
			double halfScreen = Screen.width / 2.0;

			//Check if it is left or right?
			if (touchPosition.x < halfScreen - 100) {
				horizontal = -1;
				isJump = false;
			} else if (touchPosition.x > halfScreen + 100) {
				horizontal = 1;
				isJump = false;
			} else if (touchPosition.x < halfScreen + 100 && touchPosition.x > halfScreen - 100) {
				isJump = true;

			}
		} else {
			horizontal = 0;
			isJump = false;

		}

	}

	// Update is called once per frame
	void FixedUpdate () {





		TouchScreen();
		isGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		HandleMovement (horizontal);



	}


	private void HandleMovement(float horizontal){
		if (horizontal > 0) {
			if (currSpeed > 0) {
				currSpeed = currSpeed + acceleration;
			} else {
				currSpeed = acceleration;
			}
			currSpeed = Math.Min (currSpeed, maxSpeed);
			myRigidBody.velocity = new Vector2 (horizontal * currSpeed, myRigidBody.velocity.y);
		} else if (horizontal < 0) {
			if (currSpeed < 0) {
				currSpeed = currSpeed - acceleration;
			} else {
				currSpeed = -acceleration;
			}
			currSpeed = Math.Max (currSpeed, -1 * maxSpeed);
			myRigidBody.velocity = new Vector2 (-1 * horizontal * currSpeed, myRigidBody.velocity.y);
		} else {
			currSpeed = 0;
			myRigidBody.velocity = new Vector2 (currSpeed, myRigidBody.velocity.y);	
		}
		if(isJump && isGround){
			isGround = false;
			isJump = false;
			myRigidBody.velocity = new Vector2(0, jumpForce);
		}

	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag != "Finish") {

			Destroy (col.gameObject);

		}


	}

}


