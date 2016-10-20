using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour 
{
	[Header("General")]

	public Transform target;
	public float range = 15.0f;
	public float turnSpeed = 10.0f;

	[Header("Use Bullets (default)")]
	public float fireRate = 1.0f;
	private float fireCountdown = 0.0f;

	[Header("Use Lazer")]
	public bool useLazer = false;
	public LineRenderer lineRenderer;
	public ParticleSystem impactParticle;
	public Light impactLight;

	[Header("SetUp Fields")]


	public string enemyTag = "Enemy";

	public GameObject bulletPrefab;
	public Transform firePoint;

	public Transform partToRotate;
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("UpdateTarget", 0.0f, 0.5f);
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) 
		{
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if(distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}

		}
		
		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
		}
		else 
		{
			target = null;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target == null)
		{
			if(useLazer)
			{
				if(lineRenderer.enabled)
				{
					lineRenderer.enabled = false;
					impactParticle.Stop();
					impactLight.enabled = false;
				}
			}
			return;
		}

		LookOnTarget ();

		if (useLazer) 
		{
			Laser ();
		} 
		else 
		{
			if (fireCountdown <= 0.0f) 
			{
				Shoot();
				fireCountdown = 1.0f / fireRate;
			}
			
			fireCountdown -= Time.deltaTime;
		}

	}

	void Laser()
	{
		if (!lineRenderer.enabled) 
		{
			lineRenderer.enabled = true;
			impactParticle.Play();
			impactLight.enabled = true;
		}
		lineRenderer.SetPosition (0, firePoint.position);
		lineRenderer.SetPosition (1, target.position);
		
		Vector3 dir = firePoint.position - target.position;

		impactParticle.transform.rotation = Quaternion.LookRotation (dir);

		impactParticle.transform.position = target.position + dir.normalized;

	}

	void LookOnTarget()
	{
		
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0.0f, rotation.y, 0.0f);

	}
	void Shoot()
	{
		GameObject curBullet = (GameObject)Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = curBullet.GetComponent<Bullet>();

		if (curBullet != null)
			bullet.Seek (target);

	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
