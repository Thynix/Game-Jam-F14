﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public Transform[] waypoints;
	private Transform currentWaypoint;
	private int currentIndex;
	
	private float moveSpeed = 10.0f;
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
			if (Vector3.Angle(transform.forward, direction) > 10) {
				var towards = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 4*Time.deltaTime);
				rigidbody.MoveRotation(towards);
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
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), Time.deltaTime);
	}
}
