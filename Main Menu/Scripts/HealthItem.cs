/// <summary>
/// Health item.
/// Wil be attached to Spawner
/// </summary>
using UnityEngine;
using System.Collections;

public class HealthItem : MonoBehaviour {

	private int restore = 20;
	

	void OnCollisionEnter2D(Collision2D coll){
		// checks if the gameObject that touches this has a tag "Player"
		if (coll.gameObject.tag.Equals ("Player"))
		{
			// grabs the GameObject(Player) and get the script attached called pHealth
			pHealth playerHealth = coll.gameObject.GetComponent<pHealth>();
			// the the function in pHealth and give the player amount of "restore" to health 
			playerHealth.updateHealth (restore);

			// this destroys the object after it gives the player health
			Destroy(this.gameObject);
		}
	}


	
}
