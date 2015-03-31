/// <summary>
/// P health.
/// Attached to MainCharacter Prefab
/// </summary>

using UnityEngine;
using System.Collections;

public class pHealth : MonoBehaviour{

	private int curHealth;
	private int maxHealth;
	private bool isDead;

	public pHealth()
	{
		curHealth = 100;
		maxHealth = 100;
		isDead = false;
	}
	
	// Getters
	public int getMax(){
		return maxHealth;
	}

	public int getHealth(){
		return curHealth;
	}

	public bool checkDead(){
		// sets the bool if player is alive or not
		if (curHealth <= 0)
			isDead = true;
		else {
			isDead = false;
		}
		
		return isDead;
	}

	public void updateHealth(int hp){
	// user cannot gain hp when he reaches 0
		if (curHealth != 0)
			curHealth += hp;
	// hp should not reach negative values
		if (curHealth < 0)
			curHealth = 0;
	// hp should not go over maxHealth	
		if (curHealth > maxHealth)
			curHealth = maxHealth;
	}
}
