using UnityEngine;
using System.Collections;

public class batteryCharger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			GlobalValues.S.inBatteryRange = true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			GlobalValues.S.inBatteryRange = false;
		}
	}
}
