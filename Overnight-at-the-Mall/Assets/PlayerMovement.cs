using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	Dictionary<KeyCode, Vector3> controls = new Dictionary<KeyCode, Vector3>
	{
		{KeyCode.W, new Vector3(0, 1, 0)},
		{KeyCode.S, new Vector3(0, -1, 0)},
		{KeyCode.A, new Vector3(1, 0, 0)},
		{KeyCode.D, new Vector3(-1, 0, 0)},
	};

	// 10 meters / second -- TODO: Why is it this? Unit vector * this * seconds?
	public float moveSpeed;

	public Vector3 lastFootstep;

	public float stepDistance;

	AudioSource[] sources;

	public GameObject level2;

	
	// Use this for initialization
	void Start () {
		lastFootstep = this.transform.position;
		Physics.gravity = new Vector3(0, 0, -130f);
		sources = this.GetComponentsInChildren<AudioSource>();
		level2 = GameObject.Find("level 2");
	}
	
	// Update is called once per frame
	void Update () {
		if(GlobalValues.S.isGameOver()){
			return;
		}
		Vector3 velocity = new Vector3();
		foreach (var item in controls) {
			if (Input.GetKey(item.Key)) {
				velocity += item.Value;
			}
		}

		if (Vector3.Distance(this.transform.position, lastFootstep) > stepDistance) {
			AudioSource step;
			int tried = 0;
			do {
				step = sources[Random.Range(0, sources.Length)];
				tried++;
			} while(step.isPlaying && tried < sources.Length);
			step.Play();

			lastFootstep = this.transform.position;
		}

		velocity.Normalize();
		this.gameObject.rigidbody.velocity = velocity * moveSpeed * Time.deltaTime;

		level2.gameObject.SetActive(this.transform.position.z > 1);
	}

}
