using UnityEngine;
using System.Collections;

public class InGame : MonoBehaviour {

	// Used to get the player health
	private GameObject Player;
	private pHealth playerHealth;


	// Enemy GameObject used to keep track of score
	private GameObject EnemyPrefab;

	// used to update the score
	private GameObject scoreObject;
	private Score scoreTracker;

	// booleans to pause the game
	private bool paused = false;
	private bool playerDead = false;

	// Use this for initialization
	void Start () {
		// so when u restart or go to menu this scene is not paused
		Time.timeScale = 1f;

		// intializes player info to variables set earlier
		Player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = Player.GetComponent<pHealth>();

		// initializes refference to score
		scoreObject = GameObject.FindGameObjectWithTag ("Score");
		scoreTracker = scoreObject.GetComponent<Score> ();
	}
	
	// Update is called once per frame
	void Update () {
		// checks if player presses pause key
		if(Input.GetKeyDown(KeyCode.P))
		paused = togglePause();

		// constantly checks if player is deads
		if (playerHealth.checkDead ())
		playerDead = playerHealth.checkDead ();
	}

	void OnGUI()
	{
		// A Box at the top right of the screen to show score
		GUI.Box(new Rect(Screen.width * .75f, 10, Screen.width * 0.25f, 20), "Score:" + scoreTracker.returnScore());

		// a Box at the top left of the screen to display players current health
		GUI.Box(new Rect(10, 10, Screen.width * 0.25f, 20), playerHealth.getHealth() + "/" + playerHealth.getMax ());

		// code for paused
		if(paused)
		{
			// next 3 lines random stuff to make it look nice
			GUIStyle myStyle = new GUIStyle();
			myStyle.fontSize = 50;
			GUI.color = Color.yellow;
			// the label *placement sucks dont know how to fix*
			GUI.Label (new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .5f, Screen.height * .1f), "PAUSED", myStyle);

			// buttons u can press during pause
			// Resume Button
			if(GUI.Button(new Rect(Screen.width * .2f, Screen.height * .75f, Screen.width * .2f, Screen.height * .1f),"RESUME"))
				paused = togglePause();
			// Restart Button
			if(GUI.Button(new Rect(Screen.width * .4f, Screen.height * .75f, Screen.width * .2f, Screen.height * .1f),"RESTART"))
				Application.LoadLevel (Application.loadedLevelName);
			// Main Menu Button
			if (GUI.Button (new Rect(Screen.width * .6f, Screen.height * .75f, Screen.width * .2f, Screen.height * .1f), "QUIT")){
				//Time.timeScale = 1f;
				Application.LoadLevel("Main Menu");
			}
		}

		// code when player dies
		if(playerDead)
		{
			StopGame ();
			GUIStyle myStyle = new GUIStyle();
			myStyle.fontSize = 50;
			GUI.color = Color.red;
			// Game Over Label
			GUI.Label (new Rect (Screen.width * .3f, Screen.height * .25f, Screen.width * .5f, Screen.height * .1f), "GAME OVER", myStyle);
			// Restart Button
			if(GUI.Button(new Rect(Screen.width * .25f, Screen.height * .75f, Screen.width * .25f, Screen.height * .1f),"RESTART"))
				Application.LoadLevel (Application.loadedLevelName);
			// Main Menu Button
			if (GUI.Button (new Rect(Screen.width * .5f, Screen.height * .75f, Screen.width * .25f, Screen.height * .1f), "QUIT")){
				//Time.timeScale = 1f;
				Application.LoadLevel("Main Menu");
			}
		}
	}

	// pauses the game
	// Time.timeScale = 0 is pause
	public bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
	}

	public void StopGame(){
		Time.timeScale = 0f;
	}
}
