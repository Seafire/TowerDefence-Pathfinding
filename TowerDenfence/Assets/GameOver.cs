using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour 
{
	public Text roundsText;

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
		Application.LoadLevel (0);
	}

	public void Menu()
	{
		Debug.Log ("Go to main menu!");
	}
}
