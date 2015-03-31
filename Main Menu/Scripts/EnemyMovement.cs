/// <summary>
/// Enemy movement.
/// Attached to Enemy Prefab
/// </summary>
using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	// variables for attacking cooldown
	private float attackTimer = 0f;
	private float cooldown = 3f;

	// scripts to access score
	private GameObject scoreObject;
	private Score scoreTracker;
	
	// takes in enemy components (animation, health and attack)
	// so EnemyMovement is able to access them
	private Animator anim;
	private EnemyAttack attack;
	private EnemyHealth health;

	// new Raycast (used for detecting if an object is hit within a range)
	private RaycastHit2D hit;

	// checks if character is facing right
	private bool facingRight = true;

	// accessing Player scripts
	private GameObject Player;
	private pHealth playerHealth ;
	
	// variables for enemy movement
	private Vector2 speed = new Vector2(5, 0);
	private Vector2 direction = new Vector2(-1, 0);
	private Vector2 movement;
	public float jumpForce = 700f;

	// variables to check if enemy is in motion
	private Vector3 oldPosition;
	private float distance;
	
	// called when gameObject is intialized
	void Start(){
		// gets the Animator, EnemyAttack, EnemyHealth Script attached to enemy
		anim = GetComponent<Animator> ();
		attack = GetComponent<EnemyAttack> ();
		health = GetComponent<EnemyHealth> ();

		// gets the gameobject with tag "Player" and sets it to Player GameObject variable
		// then get pHealth component of Player
		Player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = Player.GetComponent<pHealth>();

		// gets the gameobject with tag "Score" and sets it to scoreObject
		// then gets scoreTracker component of scoreObject
		scoreObject = GameObject.FindGameObjectWithTag ("Score");
		scoreTracker = scoreObject.GetComponent<Score> ();
	}

	// called once per frame
	void Update()
	{
		// updates attackTimer to lower
		if(attackTimer > 0)
			attackTimer -= Time.deltaTime;
		
		if(attackTimer < 0)
			attackTimer = 0;

		// checks each frame is player is dead
		if (health.checkDead ()) {
			scoreTracker.updateScore (health.givePoints());
			Destroy(this.gameObject);
		}
		// if Player is dead call Stop()
		if (playerHealth.checkDead ()) {
			Stop ();
		} 
		// if player is not dead
		else {
			// gets the x distance between player and enemy 
			distance = Mathf.Abs (transform.position.x - Player.transform.position.x);

			// if enemy is in range
			if (distance < 1) {
				// stops the enemy movement
				movement = new Vector2 (0, 0);

				// sends out a "Ray" and returns true if hit
				// code for when enemy is facing left or right so its send out the ray the right direction
				// "1 << LayerMask.NameToLayer("Player")" makes sure that the object hit is in the layer called "Player"

				if (facingRight){
					hit = Physics2D.Raycast(transform.position, transform.right, 2f, 1 << LayerMask.NameToLayer("Player"));
				} else {
					hit = Physics2D.Raycast(transform.position, transform.right, -2f, 1 << LayerMask.NameToLayer("Player"));
				}

				// if the ray hits, set attack animation and damage player
				if (hit && attackTimer == 0) {   
					anim.SetBool ("Attack", true );
					playerHealth.updateHealth (attack.giveDmg ());
					attackTimer = cooldown;
				}

			// if enemy is not in range
			}else {
				// stop attack animation
				anim.SetBool ("Attack", false );
				// if player is ahead of enemy move right (x = 1)
				if (Player.transform.position.x > transform.position.x) {
					movement = new Vector2 (speed.x * 1, speed.y * direction.y);
				// if player is behind the enemy move left (x = -1)
				} else {
					movement = new Vector2 (speed.x * -1, speed.y * direction.y);
				}

				// if player is above then give enemy a vertical force
				if (Player.transform.position.y > transform.position.y){
					rigidbody2D.AddForce(new Vector2(0, 700f));
				}
			}
		}

		// checks if enemy is facing the right way
		if (movement.x > 0 && !facingRight)
			Flip();
		else if(movement.x < 0 && facingRight)
			Flip();
			
		// Apply movement to the rigidbody
		rigidbody2D.velocity = movement;

		// checks if character has moved based on last fixedupdate
		// if different play walk animaiton otherwise dont play it
		if(oldPosition == transform.position){
			anim.SetBool ("Moving", false );
		}
		else{
			anim.SetBool ("Moving",  true);
		}
		oldPosition = transform.position;
	}
	
	void Flip() { 
		// reverses the character sprite to face the right direction
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	// stops enemy movement and stop attack animation
	void Stop(){
		movement = new Vector2 (0, 0);
		anim.SetBool ("Attack", false );
	}
}
