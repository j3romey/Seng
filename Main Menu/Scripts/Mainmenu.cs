/// <summary>
/// Mainmenu.
/// Attached to Main Camera
/// </summary>
using UnityEngine;
using System.Collections;

public class Mainmenu : MonoBehaviour {

	public Texture backgroundTexture;

	// manually set button placement 
	public float guiPlacementY;

	void OnGUI(){

	// Display our background
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

	// Displlay Buttons
	// 1st/2nd arg (where to start horizontal/vertical), 3rd/4th arg (how big button is)
		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .50f, Screen.width * .5f, Screen.height * .1f), "Play Game")){

		// Loads the scene name (Must be in biulder)
			Application.LoadLevel("InGame");
		}

		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .65f, Screen.width * .5f, Screen.height * .1f), "Settings")){
			Application.LoadLevel("Settings");
		}

		if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .80f, Screen.width * .5f, Screen.height * .1f), "Exit")){
			Application.Quit();
		}

	}
}
