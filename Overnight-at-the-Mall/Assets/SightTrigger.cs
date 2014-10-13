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
		if (other.tag == "Player") {		
			//do raycasts to check
			print ("HIT");
			Transform body= transform.parent;
			RaycastHit rayInfo;
			if(Physics.Raycast(body.position, other.transform.position-body.position, out rayInfo)){
				if(rayInfo.collider.tag=="Player"){
					gameOver();
				}
			}

		}
	}
	void gameOver(){
		//do game over stuff
		print ("GAME OVER");
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Vector3 direction = transform.TransformDirection (Vector3.forward) * 5;
		Gizmos.DrawRay (transform.position, direction);
	}
}
