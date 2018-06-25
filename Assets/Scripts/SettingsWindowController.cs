using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindowController : MonoBehaviour {

	public GameObject settingsWindowPrefab;
	private GameObject window;

	public void closeSettingsWindow()
	{
		Destroy(GameObject.Find("Canvas/SettingsWindow(Clone)"));
	}

	public void openSettingsWindow()
	{
		window = Instantiate(settingsWindowPrefab);
		window.transform.SetParent(GameObject.Find("Canvas").transform, false);
	}
}
