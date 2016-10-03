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

	public GameObject buildAffect;

	private TurretBluePrint turretToBuild;
	
	public bool CanBuild{get{return turretToBuild != null; }}

	public bool HasMoney{get{return PlayerStats.money >= turretToBuild.cost; }}

	public void BuildTurretOn(Node node)
	{
		if (PlayerStats.money < turretToBuild.cost) 
		{
			Debug.Log("Not Enough Money to Buy");
			return;
		}

		PlayerStats.money -= turretToBuild.cost;

		GameObject turret = (GameObject)Instantiate (turretToBuild.prefab, node.GetBuildPosition (), Quaternion.identity);
		node.turret = turret;

		GameObject Affect = (GameObject)Instantiate (buildAffect, node.GetBuildPosition(), Quaternion.identity);
		Destroy (Affect, 5.0f);

		Debug.Log ("Turret Built" + PlayerStats.money);
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
