using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour 
{
	public Color hoverColour;
	public Vector3 offset;

	private GameObject turret;

	private Renderer rend;
	private Color startColour;

	BuildManager buildManager;
	// Use this for initialization
	void Start () 
	{
		rend = GetComponent<Renderer>();
		startColour = rend.material.color;
		buildManager = BuildManager.instance;
	}

	void OnMouseDown()
	{

		if (EventSystem.current.IsPointerOverGameObject ())
			return;

		if (turret != null) 
		{
			// Later development - Display to the user on screen 
			Debug.Log ("Can't build there!");
			return;
		}

		// Build a turret
		GameObject turretToBuild = buildManager.GetTurretToBuild();
		turret = (GameObject)Instantiate (turretToBuild, transform.position + offset, transform.rotation);

	}

	void OnMouseExit ()
	{
		rend.material.color = startColour;
	}
	// Update is called once per frame
	void OnMouseEnter () 
	{
		if (EventSystem.current.IsPointerOverGameObject ())
			return;

		if (buildManager.GetTurretToBuild () == null) 
		{
			return;
		}

		rend.material.color = hoverColour;
	}
}
