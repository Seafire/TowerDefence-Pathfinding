using UnityEngine;

public class Bullet : MonoBehaviour 
{
	private Transform target;

	public float speed = 70.0f;
	public float expRadius = 0.0f;
	public GameObject impactAffect;

	public void Seek (Transform _target)
	{
		target = _target;
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target == null) 
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float disThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= disThisFrame) 
		{
			HitTarget();
			return;
		}

		transform.Translate (dir.normalized * disThisFrame, Space.World);

		transform.LookAt (target);
	}

	void HitTarget()
	{
		GameObject effectInst =  (GameObject)Instantiate (impactAffect, transform.position, transform.rotation);
		Destroy (effectInst, 2.0f);

		if (expRadius > 0.0f)
		{
			Explode();
		} 
		else
		{
			Damage (target);
		}

		Destroy (gameObject);
	}

	void Explode()
	{
		Collider[] colliders = Physics.OverlapSphere (transform.position, expRadius);

		foreach (Collider collider in colliders) 
		{
			if (collider.tag == "Enemy")
			{
				Damage(collider.transform);
			}
		}
	}

	void Damage(Transform enemy)
	{
		Destroy (enemy.gameObject);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere (transform.position, expRadius);
		Gizmos.color = Color.red;
	}
}
