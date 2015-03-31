/// <summary>
/// Spawner.
/// Attached to EnemySpawn and HealthSpawn prefab
/// </summary>
using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// we will insert a GameObject here in the Interface on Unity
	public GameObject[] obj;
	
	public int maxSpawn = 1;
	public int deathCounter = 0;
	public int increaseCounter;

	// creates an array of gameObject (enemies to be specific)
	private GameObject[] enemies;

	// Use this for initialization
	void Start () {
		// calls spawn once in the beginning
		Spawn ();
	}
	
	void Spawn(){
		// creates a Game	
		Instantiate (obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
	}

	// called on each frame
	void Update () {
		// the old array is replaced with a new array 
		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		// if there are less enemies on the screen than the maxSpawn, call Spawn()
		if (enemies.Length < maxSpawn){
			Spawn ();
			// since we spawn another enemy that means one died, therefore increase deathCounter
			deathCounter++;
			// once the deathCounter is equal to the maxSpawn, increase the amount of enemies you can spawn
			// this kind of simulates increasing difficulty as more enemies are defeated
			if(deathCounter == maxSpawn){
				maxSpawn++;
				deathCounter = 0;
			}

		}

	}

}