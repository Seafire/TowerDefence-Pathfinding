using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour 
{
	public static BuildManager instance;

	void Awake()
	{
		if (instance != null) 
		{
			Debug.LogError("More than one build manager in Scene");
			return;
		}
		instance = this;
	}

	public GameObject standardTurretPrefabe;

	private GameObject turretToBuild;

	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}

	// Use this for initialization
	void Start ()
	{
		turretToBuild = standardTurretPrefabe;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
