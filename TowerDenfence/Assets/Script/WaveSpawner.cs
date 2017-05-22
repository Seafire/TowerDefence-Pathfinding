using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
	public static int EnemiesAlive = 0;

	public Wave[] waves;
	public Transform spawnPoint;

	public float countdownTimer = 10.0f;

	public Text waveCountDownText;

	private float countdown = 2.0f;
	private int waveIndex = 0;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (EnemiesAlive > 0)
			return;

		if (countdown <= 0.0f)
		{
			StartCoroutine  (SpawnWave());
			countdown = countdownTimer;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp (countdown, 0.0f, Mathf.Infinity);

		waveCountDownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.rounds++;

		Wave wave = waves [waveIndex];
		for (int i = 0; i < wave.count; i++) 
		{
			SpawnEnemy (wave.enemyPrefab);
			yield return new WaitForSeconds(1f / wave.spawnRate);
		}
		waveIndex++;

		if (waveIndex == waves.Length)
		{
			Debug.Log ("Level won");
			this.enabled = false;
		}
	}

	void SpawnEnemy (GameObject enemy)
	{
		Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
		EnemiesAlive ++;
	}
}
