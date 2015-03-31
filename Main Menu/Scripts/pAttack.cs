/// <summary>
/// P attack.
/// Will be attached to MainCharacter Prefab
/// </summary>
using UnityEngine;
using System.Collections;

public class pAttack : MonoBehaviour {

	private int damage = -25;

	// returns damage
	public int giveDmg(){
		return damage;
	}
}
