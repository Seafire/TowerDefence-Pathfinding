using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public string LevelToLoad = "MainLevel";
	public void Play ()
	{
		Debug.Log("Play");
		Application.LoadLevel (LevelToLoad);
	}

	public void Quit ()
	{
		Debug.Log("Quit");
		Application.Quit ();
	}
}
