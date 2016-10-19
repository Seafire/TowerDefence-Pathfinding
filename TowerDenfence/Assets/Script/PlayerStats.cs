using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
	public static int money;
	public int startMoney = 500;

	public static int lives;
	public int startLives = 12;

	// Use this for initialization
	void Start ()
	{
		money = startMoney;
		lives = startLives;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
