using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	public float speed = 10.0f;

	public int enemyHealth = 100;
	public int moneyInc = 50;

	public GameObject deathAffect;

	private Transform target;
	private int waypointIndex = 0;
	// Use this for initialization
	void Start () 
	{
		target = Waypoints.points [0];
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <=0.2f)
		{
			GetNextWaypoint();
		}
	}

	public void EnemyDamage(int amount)
	{
		enemyHealth -= amount;

		if (enemyHealth <= 0) 
		{
			EnemyDie();
		}
	}

	void EnemyDie()
	{
		GameObject affect = (GameObject)Instantiate (deathAffect, transform.position, Quaternion.identity);
		PlayerStats.money += moneyInc;
		Destroy (affect, 5.0f);
		Destroy (gameObject);
	}

	void GetNextWaypoint()
	{
		if (waypointIndex >= Waypoints.points.Length - 1) 
		{
			PathEnd();
			return;
		}
		waypointIndex ++;
		target = Waypoints.points[waypointIndex];
	}

	void PathEnd()
	{
		PlayerStats.lives--;
		Destroy(gameObject);
	}
}
