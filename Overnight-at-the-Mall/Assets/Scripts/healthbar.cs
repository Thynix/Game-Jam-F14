using UnityEngine;
using System.Collections;

public class healthbar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Texture2D bgImage; // background image that is 256 x 32 (coud be a different size, but has to match the sizes below (GUI.BeginGroup (Rect (0,0,256,32));)
	Texture2D fgImage; // foreground image that is 256 x 32
	float duration = 1.0f; //how long the healthbar will last
	private float time;
	/*
	void OnGUI () {
		//increase the amount of time each frame, clamp it so it doesn't go higher than duration
		time = Mathf.Clamp (time + Time.deltaTime, 0, duration);
			
			// Create one Group to contain both images
			// Adjust the first 2 coordinates to place it somewhere else on-screen
			//adjust the last 2 coordinates to change the size
			GUI.BeginGroup(new Rect (0,0,256,32));
		
		// Draw the background image
		GUI.Box (Rect (0,0,256,32), bgImage);
		
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (Rect (0,0,(time-duration)/duration * 256, 32));
		
		// Draw the foreground image
		GUI.Box (Rect (0,0,256,32), fgImage);
		
		// End both Groups
		GUI.EndGroup ();
		GUI.EndGroup ();
	}*/
}
