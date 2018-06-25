using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour {
	
	public AudioClip music = null;
	AudioSource musicSource = null;

	// Use this for initialization
	void Start () {
		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource.clip = music;
		musicSource.loop = true;
		musicSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
