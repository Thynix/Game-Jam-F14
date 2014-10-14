using UnityEngine;
using System.Collections;

public class GlobalValues : MonoBehaviour {

	public static GlobalValues S;
	private bool gameComplete = false;
	private bool gameOver = false;
	private float startingTime = 8.0f;

	private 
	void Awake(){
		S = this;
	}

	void Update(){
	}
	public void Died(){
		gameOver = true;
	}
	public bool isGameOver(){
		return gameOver;
	}
	public float startTime(){
		return startingTime;
	}
	public void timeOver(){
		gameComplete = true;
	}
	public bool isGameDone(){
		return gameComplete;
	}
}
