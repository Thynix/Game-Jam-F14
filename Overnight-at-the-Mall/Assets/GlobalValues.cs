using UnityEngine;
using System.Collections;

public class GlobalValues : MonoBehaviour {

	public static GlobalValues S;

	void Awake(){
		S = this;
	}

	private bool gameOver = false;


	public void Died(){
		gameOver = true;
	}
	public bool isGameOver(){
		return gameOver;
	}
}
