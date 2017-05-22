using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour 
{

	
	private Transform target;
	private int waypointIndex = 0;
	private Enemy enemy;
	// Use this for initialization
	void Start () 
	{
		target = Waypoints.points [0];
		enemy = GetComponent<Enemy> ();
	}
	
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * enemy.speed * Time.deltaTime, Space.World);
		
		if (Vector3.Distance(transform.position, target.position) <=0.2f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
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
		WaveSpawner.EnemiesAlive --;
		Destroy(gameObject);
	}
}
