using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
	public Transform enemyPrefab;
	public Transform spawnPoint;

	public float countdownTimer = 10.0f;

	public Text waveCountDownText;

	private float countdown = 2.0f;
	private int waveNumber = 0;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (countdown <= 0.0f)
		{
			StartCoroutine  (SpawnWave());
			countdown = countdownTimer;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp (countdown, 0.0f, Mathf.Infinity);

		waveCountDownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave()
	{
		
		waveNumber++;

		for (int i = 0; i < waveNumber; i++) 
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}
	}

	void SpawnEnemy ()
	{
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
