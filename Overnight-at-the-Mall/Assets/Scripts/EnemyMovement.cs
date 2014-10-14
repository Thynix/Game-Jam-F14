using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {

	public string pathName;

	private Vector3 currentWaypoint;
	private int currentIndex;

	private float moveSpeed = 5.0f;
	private float minDistance = 0.5f;
	private List<Vector3> waypoints;

	private Vector3 startingPosition;
	public bool sentry = false;

	// Use this for initialization
	void Start () {
		waypoints = new List<Vector3>();

		var path_input = Resources.Load<TextAsset>(pathName);
		var json = new JSONObject(path_input.text);
		var path = json[0];

		foreach (var waypoint in path.list) {
			waypoints.Add(new Vector3(waypoint[0].f, waypoint[1].f, waypoint[2].f));
		}

		currentWaypoint = waypoints[0];
		currentIndex = 0;
		startingPosition = this.transform.position;
		Describe();
	}

	void Describe() {
		//Debug.Log("Moving from " + Location() + " to " + currentWaypoint.ToString());
	}

	Vector3 Location() {
		return this.gameObject.transform.position - startingPosition;
	}

	// Update is called once per frame
	void Update () {
		//game over logic
		if (GlobalValues.S.isGameDone () || sentry) {
			return;
		}
		if (GlobalValues.S.isGameOver()) {
			Vector3 playerDirection = GameObject.Find("Player").transform.position - transform.position;
			playerDirection.z = 0;
			transform.forward = Vector3.RotateTowards(transform.forward, playerDirection.normalized, Time.deltaTime*3, 1);
			return;
		}
		if (Vector3.Distance(currentWaypoint, Location()) < minDistance) {
			int nextIndex = currentIndex;
			++nextIndex;
			if (nextIndex > waypoints.Count - 1) {
				nextIndex = 0;
			}
			Vector3 direction = waypoints[nextIndex] - Location();
			Describe();

			if (Vector3.Angle(transform.forward, direction) > 1) {
				//Debug.DrawRay(transform.position, direction, Color.green, 10f);
				//Debug.DrawRay(transform.position, transform.forward, Color.cyan, 10f);

				transform.forward = Vector3.RotateTowards(transform.forward, direction.normalized, Time.deltaTime, 1);
			}
			else {
				currentIndex = nextIndex;
				currentWaypoint = waypoints[currentIndex];
			}
		} else {
			MoveTowardWaypoint();
		}
	}
	private void MoveTowardWaypoint(){
		Vector3 direction = currentWaypoint - Location();
		Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
		transform.position += moveVector;
	}

}
