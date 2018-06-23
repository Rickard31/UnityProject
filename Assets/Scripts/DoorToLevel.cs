using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using SceneSwitcher;

public class DoorToLevel : MonoBehaviour
{
	public String levelSceneName = "MainMenu";
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (this.isActiveAndEnabled)
		{
			SceneSwitcher.goToScene(this.levelSceneName);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
