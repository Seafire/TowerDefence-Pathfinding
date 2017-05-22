using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	public float startSpeed = 10.0f;
	[HideInInspector]public float speed;

	public float startHealth = 100;
	private float health;

	public float enemyHealth = 100.0f;
	public int moneyInc = 50;

	public GameObject deathAffect;

	[Header("Unity Stuff")]
	public Image healthBar;

	void Start ()
	{
		speed = startSpeed;
		health = startHealth;
	}

	public void EnemyDamage(float amount)
	{
		health -= amount;

		healthBar.fillAmount = health / startHealth;

			if (health <= 0) 
		{
			EnemyDie();
		}
	}

	public void Slow (float amount)
	{
		speed = startSpeed * (1.0f - amount);
	}

	void EnemyDie()
	{
		GameObject affect = (GameObject)Instantiate (deathAffect, transform.position, Quaternion.identity);
		PlayerStats.money += moneyInc;
		Destroy (affect, 5.0f);

		WaveSpawner.EnemiesAlive --;

		Destroy (gameObject);
	}

}
