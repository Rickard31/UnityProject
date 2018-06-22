using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private static String levelSelectionName = "LevelSelection";
	public void goToLevelSelection()
	{
		SceneManager.LoadScene(levelSelectionName);
	}


	private static String level1Name = "Level1";
	public void GoToLevel1()
	{
		//Debug.Log("GoToLevel1");
		SceneManager.LoadScene(level1Name);
	}
	
	private static String level2Name = "Level2";
	public void GoToLevel2()
	{
		//Debug.Log("GoToLevel2");
		SceneManager.LoadScene(level2Name);
	}
}
