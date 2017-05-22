using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public string LevelToLoad = "MainLevel";
	public SceneFader sceneFader;

	public void Play ()
	{
		sceneFader.FadeTo (LevelToLoad);
	}

	public void Quit ()
	{
		Debug.Log("Quit");
		Application.Quit ();
	}
}
