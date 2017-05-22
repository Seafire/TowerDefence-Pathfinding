﻿using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour 
{
	public GameObject ui;
	public string menuSceneName = "MainMenu";
	public SceneFader sceneFader;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P))
		{
			Toggle ();
		}
	}

	public void Toggle ()
	{
		ui.SetActive (!ui.activeSelf);

		if (ui.activeSelf)
		{
			Time.timeScale = 0.0f;
		}
		else
		{
			Time.timeScale = 1.0f;
		}
	}

	public void Retry ()
	{
		Toggle ();
		sceneFader.FadeTo (Application.loadedLevelName);
	}

	public void Menu ()
	{
		Toggle ();
		sceneFader.FadeTo ("menuSceneName");
	}
}
