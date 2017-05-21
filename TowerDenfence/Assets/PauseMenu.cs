using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour 
{
	public GameObject ui;

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
		Time.timeScale = 1.0f;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void Menu ()
	{
		Debug.Log ("Go TO MENU");
	}
}
