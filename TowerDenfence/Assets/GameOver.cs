using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour 
{
	public Text roundsText;
	public string menuSceneName = "MainMenu";
	public SceneFader sceneFader;

	void OnEnable()
	{
		roundsText.text = PlayerStats.rounds.ToString ();
	}

	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Retry()
	{
		sceneFader.FadeTo (Application.loadedLevelName);
	}

	public void Menu()
	{
		sceneFader.FadeTo (menuSceneName);
	}
}
