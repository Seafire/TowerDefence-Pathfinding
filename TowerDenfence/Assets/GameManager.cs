using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public static bool gameOver;

	public GameObject gameOverUI;

	void Start()
	{
		gameOver = false;
	}


	// Update is called once per frame
	void Update () 
	{
		if (gameOver)
			return;

		if (PlayerStats.lives <= 0)
		{
			EndGame ();
		}
	}

	void EndGame()
	{
		gameOver = true;
		Debug.Log ("Game Over");

		gameOverUI.SetActive (true);
	}
}
