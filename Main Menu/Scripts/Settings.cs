/// <summary>
/// Settings.
/// Added to the Camera
/// </summary>
using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	public Texture backgroundTexture;

	void OnGUI(){
		
	// Display our background
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

		if (GUI.Button (new Rect (Screen.width * .025f, Screen.height * .025f, Screen.width * .1f, Screen.height * .1f), "Back")) {
			// insert code to go back to menu here
			Application.LoadLevel("Main Menu");
		}



	}
}
