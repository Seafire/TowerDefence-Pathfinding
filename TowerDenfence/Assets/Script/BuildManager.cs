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

	public GameObject standardTurretPrefab;
	public GameObject missileTurretPrefab;

	private TurretBluePrint turretToBuild;
	
	public bool CanBuild{get{return turretToBuild != null; }}

	public void BuildTurretOn(Node node)
	{
		GameObject turret = (GameObject)Instantiate (turretToBuild.prefab, node.GetBuildPosition (), Quaternion.identity);
		node.turret = turret;
	}

	public void SelectTurretToBuild(TurretBluePrint turret)
	{
		turretToBuild = turret;
	}
	
	// Use this for initialization
//	void Start ()
//	{
//		turretToBuild = standardTurretPrefabe;
//	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
