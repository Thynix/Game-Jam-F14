using UnityEngine;
using System.Collections;

public class SightTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		checkPlayer (other);
	
	}
	void OnTriggerStay(Collider other){
		checkPlayer (other);
	}
	void gameOver(Collider other){
		//do game over stuff
		print ("GAME OVER");
		other.transform.FindChild("Face").GetComponent<MeshRenderer> ().enabled = true;
		GlobalValues.S.Died ();		// Player "Died"

	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Vector3 direction = transform.TransformDirection (Vector3.forward) * 5;
		Gizmos.DrawRay (transform.position, direction);
	}
	void checkPlayer(Collider other){
		if (other.tag == "Player") {		
			//do raycasts to check
			print ("HIT");
			Transform body = transform.parent;
			RaycastHit rayInfo;
			if (Physics.Raycast (body.position, other.transform.position - body.position, out rayInfo)) {
					if (rayInfo.collider.tag == "Player") {
							gameOver (other);
					}
			}
		}
	}
}
