using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelDoor : MonoBehaviour
{
	private WinLevelWindowController winLevelWindowController;
	public GameObject winLevelWindowPrefab;

	void Start()
	{
		this.winLevelWindowController = new WinLevelWindowController();
		this.winLevelWindowController.winLevelWindowPrefab = winLevelWindowPrefab;
	}
	

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (this.isActiveAndEnabled)
		{
			winLevelWindowController.openWinLevelWindow();
		}
	}
}
