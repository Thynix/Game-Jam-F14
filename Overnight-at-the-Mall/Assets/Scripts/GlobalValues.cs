using UnityEngine;
using System.Collections;

public class GlobalValues : MonoBehaviour {

	public static GlobalValues S;
	private bool gameComplete;
	private bool gameOver;
	private float startingTime;
	private GUIStyle style;

	private 
	void Awake(){
		S = this;
		gameComplete = false;
		gameOver = false;
		startingTime = 3.0f;
	}

	void Start() {
		style = new GUIStyle();
		style.richText = true;
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

	void OnGUI() {
		if (isGameOver()) {
			GUI.Label(new Rect(100, 100, 100, 100), "<color=white><size=20>You were caught!</size></color>", style);
			if (GUI.Button(new Rect(150, 150, 150, 20), "Admit defeat")) {
				Application.LoadLevel("TitleScreen");
			}
		}
		if (isGameDone()) {
			GUI.Label(new Rect(100, 100, 100, 100), "<color=white><size=20>You made it through the night!</size></color>", style);
			if (GUI.Button(new Rect(150, 150, 150, 20), "Bask in victory")) {
				Application.LoadLevel("TitleScreen");
			}
		}
	}
}
