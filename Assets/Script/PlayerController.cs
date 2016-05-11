using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class PlayerController : NetworkBehaviour {
	public static PlayerController pControl;
	public float moveSpeed;
	public float moveSpeedStore;
	public float speedMultiplier;

	public float speedIncreaseMilestone;
	public float speedIncreaseMileStoneStore;

	public  float speedMilestoneCount;
	public  float speedMilestoneCountStore;



	public float jumpForce;

	public float jumpTime;
	private float jumpTimeCounter;

	private bool stoppedJumping;
	private bool canDoubleJump;


	private Rigidbody2D myRigidbody;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	//private Collider2D myCollider;
	private Animator myAnimator;
	public GameManager theGameManager;
	public GameObject findGm;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		//myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();
		findGm = GameObject.Find ("Game Manager");
		theGameManager = findGm.GetComponent<GameManager>();
		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		moveSpeedStore = moveSpeed;

		speedMilestoneCountStore = speedMilestoneCount;

		speedIncreaseMileStoneStore = speedIncreaseMilestone;
		stoppedJumping = true;
		this.gameObject.name = "Player";
		CameraController.cmC.theCamera = this.GetComponent<PlayerController> ();

	}
	
	// Update is cal

	void Update () {
		if (!isLocalPlayer) {
			return;
		}
		Debug.Log (this.tag);
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		
		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		if (transform.position.x > speedMilestoneCount) 
		{
			
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

			moveSpeed = moveSpeed * speedMultiplier;
		}
		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0)){
			if (grounded) {
				
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				stoppedJumping = false;
			}

			if (!grounded && canDoubleJump) {
			
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter = jumpTime;
				stoppedJumping = false;
				canDoubleJump = false;
			
			}

		}
		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButton (0)) && !stoppedJumping) 
		{
			if (jumpTimeCounter > 0) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) 
		{
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}
		if (grounded) 
		{
			jumpTimeCounter = jumpTime;
			canDoubleJump = true;

		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);


	}
	void OnCollisionEnter2D (Collision2D other)
	{

		if (other.gameObject.tag == "killbox") {

			theGameManager.RestartGame();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;

		}
	}

	
}

