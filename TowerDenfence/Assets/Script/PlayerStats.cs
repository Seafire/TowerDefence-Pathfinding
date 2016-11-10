using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
	public static int money;
	public int startMoney = 500;

	public static int lives;
	public int startLives = 12;

	static public int rounds;

	// Use this for initialization
	void Start ()
	{
		money = startMoney;
		lives = startLives;
		rounds = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
