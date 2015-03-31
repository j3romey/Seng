/// <summary>
/// Enemy health.
/// Will be inside EnemyPreFab
/// And that PreFab will be attached to EnemySpawner
/// </summary>
using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	private int curHealth;
	private int maxHealth;
	private int points;
	private bool isDead;

	public EnemyHealth(){
		curHealth = 100;
		maxHealth = 100;
		isDead = false;
		points = 100;
	}

	// getters
	public int getMax(){
		return maxHealth;
	}
	
	public int getHealth(){
		return curHealth;
	}

	public bool checkDead(){
		if (curHealth <= 0)
			isDead = true;
		else
			isDead = false;

		return isDead;
	}

	public int givePoints(){
		if (checkDead ()){
			return points;
		}else {
			return 0;
		}
	}


	// used to update the health of enemy 
	// (when attacked by player)
	public void updateHealth(int hp){
		curHealth += hp;
		
		if (curHealth < 0)
			curHealth = 0;
		
		if (curHealth > maxHealth)
			curHealth = maxHealth;
	}
}
