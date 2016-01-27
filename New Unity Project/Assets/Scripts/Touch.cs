using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {
	public GameObject player;
	private bool isGround = false;
	private bool isJump = false;
	private Rigidbody2D myRigidBody;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	private float jumpForce = 5;

	// Use this for initialization
	void Start () {

		myRigidBody = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update () {
		

		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
		{
			Vector2 touchPosition = Input.GetTouch(0).position;
			double halfScreen = Screen.width / 2.0;

			//Check if it is left or right?
			if (touchPosition.x < halfScreen - 100) {
				player.transform.Translate (Vector3.left * 5 * Time.deltaTime);
			} else if (touchPosition.x > halfScreen + 100) {
				player.transform.Translate (Vector3.right * 5 * Time.deltaTime);
			} else if (touchPosition.x < halfScreen + 100 && touchPosition.x > halfScreen - 100) {
				

				if(isJump && isGround){
					isGround = false;
					isJump = false;
					myRigidBody.velocity = new Vector2(0, jumpForce);
				}
				

			}
				

		}

	}
}