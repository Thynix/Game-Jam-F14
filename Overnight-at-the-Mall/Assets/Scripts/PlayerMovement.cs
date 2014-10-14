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

	public GameObject level2;
	
	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0, 0, -130f);
		level2 = GameObject.Find("level 2");
	}
	
	// Update is called once per frame
	void Update () {
		if(GlobalValues.S.isGameOver()||GlobalValues.S.isGameDone()){
			return;
		}
		Vector3 velocity = new Vector3();
		foreach (var item in controls) {
			if (Input.GetKey(item.Key)) {
				velocity += item.Value;
			}
		}

		velocity.Normalize();
		this.gameObject.rigidbody.velocity = velocity * moveSpeed;// * Time.deltaTime;
		print (rigidbody.velocity);

		level2.gameObject.SetActive(this.transform.position.z > 1);
	}

}
