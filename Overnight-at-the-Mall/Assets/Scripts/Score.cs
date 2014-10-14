using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private int score;
	private GUIStyle style;

	// Use this for initialization
	void Start () {
		score = 0;
		style = new GUIStyle();
		style.richText = true;
	}

	void OnGUI() {
		GUI.contentColor = Color.white;
		GUI.Label(new Rect(0, 0, Screen.width, Screen.height), string.Format("<size=20><color=white>Score: {0}</color></size>", score), style);
	}

	public void Add(int value) {
		score += value;
	}

	// Update is called once per frame
	void Update () {
	}
}
