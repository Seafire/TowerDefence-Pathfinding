using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour 
{
	public Color hoverColour;
	public Vector3 offset;

	private GameObject turret;

	private Renderer rend;
	private Color startColour;
	// Use this for initialization
	void Start () 
	{
		rend = GetComponent<Renderer>();
		startColour = rend.material.color;
	}

	void OnMouseDown()
	{
		if (turret != null) 
		{
			// Later development - Display to the user on screen 
			Debug.Log ("Can't build there!");
			return;
		}

		// Build a turret
		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = (GameObject)Instantiate (turretToBuild, transform.position + offset, transform.rotation);

	}

	void OnMouseExit ()
	{
		rend.material.color = startColour;
	}
	// Update is called once per frame
	void OnMouseEnter () 
	{
		rend.material.color = hoverColour;
	}
}
