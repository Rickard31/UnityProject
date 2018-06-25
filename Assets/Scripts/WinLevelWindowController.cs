using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class WinLevelWindowController : MonoBehaviour {

	public GameObject winLevelWindowPrefab;
	private GameObject window;

	public void openWinLevelWindow()
	{
		window = Instantiate(winLevelWindowPrefab);
		window.transform.SetParent(GameObject.Find("Canvas").transform, false);
		
		GameObject.Find("MusicController").GetComponent<BackgroundMusicController>().playVictoryMusic();

		var gems = LevelController.current.getCollectedGems();
		if (gems.Count > 0)
		{
			window.transform.Find("crystal-1").GetComponent<Image>().sprite = gems[0];
		}
		if (gems.Count > 1)
		{
			window.transform.Find("crystal-2").GetComponent<Image>().sprite = gems[1];
		}
		if (gems.Count > 2)
		{
			window.transform.Find("crystal-3").GetComponent<Image>().sprite = gems[2];
		}

		window.transform.Find("collected-fruit-text").GetComponent<Text>().text =
			String.Empty + LevelController.current.fruits + "/" + LevelController.current.fruitsNum;

		window.transform.Find("collected-coin-text").GetComponent<Text>().text =
			"+" + LevelController.current.coins;

		GameObject.Find("Rabbit").GetComponent<HeroRabbit>().enabled = false;
		GameObject.Find("end-level-door").SetActive(false);
	}
	
	public void closeWinLevelWindow()
	{
		this.nextLevel();
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
