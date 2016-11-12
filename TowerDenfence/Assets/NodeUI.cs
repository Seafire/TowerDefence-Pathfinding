using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour 
{
	private Node target;
	public GameObject ui;

	public Text upgradeCost;
	public Button upgradeButton;


	public void SetTarget(Node _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition ();

		if (!target.isUpgraded) {
			upgradeCost.text = "$" + target.turretBluePrint.upgradeCost;
			upgradeButton.interactable = true;
		} else {
			upgradeCost.text = "MAX";
			upgradeButton.interactable = false;
		}
	
		ui.SetActive(true);
	}

	public void Hide()
	{
		ui.SetActive(false);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Upgrade()
	{
		target.UpgradeTurret ();
		BuildManager.instance.DeselectNode ();
	}
}
