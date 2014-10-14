using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public Transform[] waypoints;
	private Transform currentWaypoint;
	private int currentIndex;
	
	private float moveSpeed = 5.0f;
	private float minDistance = 0.5f;

	
	// Use this for initialization
	void Start () {
		currentWaypoint = waypoints [0];
		currentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (currentWaypoint.transform.position, transform.position) < minDistance) {
			int nextIndex = currentIndex;
			++nextIndex;
			if (nextIndex > waypoints.Length - 1) {
				nextIndex = 0;
			}
			Vector3 direction = waypoints[nextIndex].transform.position - transform.position;

			//Vector3.Angle (
			if (Vector3.Angle(transform.forward, direction) > 10) {
				//Debug.DrawRay(transform.position, direction, Color.green, 10f);
				//Debug.DrawRay(transform.position, transform.forward, Color.cyan, 10f);

				transform.forward = Vector3.RotateTowards(transform.forward, direction.normalized, Time.deltaTime, 1);
			}
			else {
				currentIndex = nextIndex;
				currentWaypoint = waypoints [currentIndex];
			}
		} else {
			MoveTowardWaypoint ();
		}
	}
	private void MoveTowardWaypoint(){
		Vector3 direction = currentWaypoint.transform.position - transform.position;
		Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
		transform.position += moveVector;
		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), Time.deltaTime);
	}
}
