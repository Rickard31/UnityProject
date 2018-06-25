using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour {
	
	public AudioClip backgroundMusic = null;
	AudioSource musicSource = null;

	// Use this for initialization
	void Start () {
		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource.clip = backgroundMusic;
		musicSource.loop = true;
		musicSource.Play ();
	}

	public AudioClip victoryMusic = null;
	public void playVictoryMusic()
	{
		Destroy(musicSource);
		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource.clip = victoryMusic;
		musicSource.loop = false;
		musicSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
