/// <summary>
/// Score.
/// Script just put in the screen 
/// </summary>

using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private int score = 0;

	public void updateScore(int add){
		score += add;
	}

	public int returnScore(){
		return score;
	}
}
