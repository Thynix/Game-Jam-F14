using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public int worth;
	public string pickUpBy = "Player";
	private Score score;

	// Use this for initialization
	void Start () {
		score = GameObject.Find("ScoreCube").GetComponent<Score>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name.Equals(pickUpBy)) {
			score.Add(worth);
			Destroy(this.gameObject);
		}
	}
}
