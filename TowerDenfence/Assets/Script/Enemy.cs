using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public float startSpeed = 10.0f;
	[HideInInspector]public float speed;

	public float enemyHealth = 100.0f;
	public int moneyInc = 50;

	public GameObject deathAffect;

	void Start ()
	{
		speed = startSpeed;
	}

	public void EnemyDamage(float amount)
	{
		enemyHealth -= amount;

		if (enemyHealth <= 0) 
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
		Destroy (gameObject);
	}

}
