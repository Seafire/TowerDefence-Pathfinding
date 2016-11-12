using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour 
{
	public Color hoverColour;
	public Color notEnoughFunds;
	public Vector3 offset;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBluePrint turretBluePrint;
	[HideInInspector]
	public bool isUpgraded = false;

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
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		//buildManager.BuildTurretOn (this);

		BuildTurret (buildManager.GetTurretToBuild());

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

		if (!buildManager.CanBuild) 
		{
			return;
		}

		if (buildManager.HasMoney)
		{
			rend.material.color = hoverColour;
		} 
		else 
		{
			rend.material.color = notEnoughFunds;
		}


	}

	void BuildTurret(TurretBluePrint bluePrint)
	{
		if (PlayerStats.money < bluePrint.cost) 
		{
			Debug.Log("Not Enough Money to Buy");
			return;
		}
		
		PlayerStats.money -= bluePrint.cost;
		
		GameObject _turret = (GameObject)Instantiate (bluePrint.prefab, GetBuildPosition (), Quaternion.identity);
		turret = _turret;

		turretBluePrint = bluePrint;
		GameObject Affect = (GameObject)Instantiate (buildManager.buildAffect, GetBuildPosition(), Quaternion.identity);
		Destroy (Affect, 5.0f);
		
		Debug.Log ("Turret Built" + PlayerStats.money);
	}

	public void UpgradeTurret()
	{
		if (PlayerStats.money < turretBluePrint.upgradeCost) 
		{
			Debug.Log("Not Enough Money to Upgrade");
			return;
		}
		
		PlayerStats.money -= turretBluePrint.upgradeCost;

		Destroy (turret);
		
		GameObject _turret = (GameObject)Instantiate (turretBluePrint.upgradedPrefab, GetBuildPosition (), Quaternion.identity);
		turret = _turret;
		
		GameObject Affect = (GameObject)Instantiate (buildManager.buildAffect, GetBuildPosition(), Quaternion.identity);
		Destroy (Affect, 5.0f);

		isUpgraded = true;

		Debug.Log ("Turret Built" + PlayerStats.money);
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + offset;
	}
}
