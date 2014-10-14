using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		Add(0);
	}

	void OnGUI() {
		GUI.Label(new Rect(0, 0, Screen.width, Screen.height), string.Format("Score: {0}", score));
	}

	public void Add(int value) {
		score += value;
	}

	// Update is called once per frame
	void Update () {
	}
}
