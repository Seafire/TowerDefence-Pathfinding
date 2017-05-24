using UnityEngine;
using System.Collections;

public class LevelSelector : MonoBehaviour 
{
	public SceneFader fader;

	public void Select (string levelName)
	{
		fader.FadeTo (levelName);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
