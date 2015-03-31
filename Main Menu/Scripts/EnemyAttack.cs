using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	// variables related to enemy attack
	private int damage = -5;
	

	// code that returns damage, as long as 
	// attack is not on cooldown
	public int giveDmg(){
			return damage;
	}


}