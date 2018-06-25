using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinLevelWindowController : MonoBehaviour {

	public GameObject winLevelWindowPrefab;
	private GameObject window;

	public void openWinLevelWindow()
	{
		window = Instantiate(winLevelWindowPrefab);
		window.transform.SetParent(GameObject.Find("Canvas").transform, false);
	}
	
	public void closeWinLevelWindow()
	{
		//Destroy(GameObject.Find("Canvas/WinLevelWindow(Clone)"));
		nextLevel();
	}

	public void replayLevel()
	{
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
	}

	public void nextLevel()
	{
		SceneSwitcher.goToLevelSelection();
	}
}
