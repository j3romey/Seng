/// <summary>
/// P controller.
/// Attached to MainCharacter Prefab
/// </summary>
using UnityEngine;
using System.Collections;

public class pController : MonoBehaviour {

	// timers to control if player will give back damage or not
	private float attackTimer = 0f;
	private float cooldown = 0.5f;

	// Scripts related to player
	private pHealth health;
	private pAttack attack;

	// takes in the animator 
	private Animator anim;

	// sets how fast the character will move
	public float maxSpeed = 10f;
	
	// bool for Flip()
	bool facingRight = true;
	
	// variables to check to play jump animation
	bool grounded = false;
	float groundRadius = 0.2f;
	public float jumpForce = 700f;
	public Transform  groundCheck;
	public LayerMask whatIsGround;

	// new Raycast (used for detecting object hit within a range)
	private RaycastHit2D hit;

	void Start () {
		// gets Components/Scripts attached to player
		anim = GetComponent<Animator> ();
		attack = GetComponent<pAttack> ();
		health = GetComponent<pHealth> ();
	}
	
	
	void FixedUpdate () {
		// code to move character
		// constantly checks character movement
		float move = Input.GetAxis ("Horizontal");
		// sets the float "Speed" in the animator (if more than 0.01 character runs)
		anim.SetFloat ("Speed", Mathf.Abs (move));
		// moves the body of the character
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		// checks in game whether the character is grounded or not
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		// statements to check if the character should be flipped or not
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();	
	}
	
	// Update is called once per frame
	void Update(){

		// Updates Attack Timer
		if(attackTimer > 0)
			attackTimer -= Time.deltaTime;
		
		if(attackTimer < 0)
			attackTimer = 0;


		// PUNCH ANIMATION
		// sends out an invisible ray and returns true if an object in the "Enemy" layer is hit by the ray
		// the if code to make sure ray is "shot" out in the right direction when player is facing left(-1f) or right(1f)
		if (facingRight){
			hit = Physics2D.Raycast(transform.position, transform.right, 1f, 1 << LayerMask.NameToLayer("Enemy"));
		} else {
			hit = Physics2D.Raycast(transform.position, transform.right, -1f, 1 << LayerMask.NameToLayer("Enemy"));
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			anim.SetBool ("Punch", true);
			if (hit && attackTimer == 0) {            
			Debug.Log(hit.collider); // will type in console saying if u hit anything

			
			// accesses the Enemy that you hit, and updates the enemy health (-25)
			hit.collider.gameObject.GetComponent<EnemyHealth>().updateHealth(attack.giveDmg());
			attackTimer = cooldown;
			}
		}
		else
			anim.SetBool ("Punch", false);

		// JUMP ANIMATION
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Ground", false);
			// gives the rigib body an upwards velocity simullating a jump
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}

	void Flip() { 
		// reverses the character sprite to face the right direction
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
