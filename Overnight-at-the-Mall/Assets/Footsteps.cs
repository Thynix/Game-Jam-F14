using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Footsteps : MonoBehaviour {

	Queue<AudioSource> sources;
	List<AudioClip> sounds;

	public string soundDirectory;
	public Vector3 lastFootstep;
	public float stepDistance;

	// Use this for initialization
	void Start () {
		sources = new Queue<AudioSource>(this.GetComponentsInChildren<AudioSource>());
		sounds = new List<AudioClip>(Resources.LoadAll<AudioClip>(soundDirectory));
		lastFootstep = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(this.transform.position, lastFootstep) > stepDistance) {
			if (sources.Peek().isPlaying)
				return;

			var source = sources.Dequeue();
			source.PlayOneShot(sounds[Random.Range(0, sounds.Count)]);
			sources.Enqueue(source);
			
			lastFootstep = this.transform.position;
		}
	}
}
