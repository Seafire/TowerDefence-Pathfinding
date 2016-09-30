using UnityEngine;

public class Shop : MonoBehaviour 
{
	BuildManager buildManager;

	// Use for the purchase of Standard Turret
	public void PurchaseStandardTurret ()
	{
		Debug.Log ("Standard Turret Selected");
		buildManager.SetTurretToBuild (buildManager.standardTurretPrefabe);
	}

	public void PurchaseMissileTurret ()
	{
		Debug.Log ("Missile Turret Purchased");
		buildManager.SetTurretToBuild (buildManager.anotherTurretPrefab);
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
