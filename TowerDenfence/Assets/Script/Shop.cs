using UnityEngine;

public class Shop : MonoBehaviour 
{

	public TurretBluePrint standardturret;
	public TurretBluePrint missileTurret;

	BuildManager buildManager;

	// Use for the purchase of Standard Turret
	public void SelectStandardTurret ()
	{
		Debug.Log ("Standard Turret Selected");
		buildManager.SelectTurretToBuild (standardturret);
	}

	public void SelectMissileTurret ()
	{
		Debug.Log ("Missile Turret Purchased");
		buildManager.SelectTurretToBuild (missileTurret);
	}


	// Use this for initialization
	void Start () 
	{
		buildManager = BuildManager.instance;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
