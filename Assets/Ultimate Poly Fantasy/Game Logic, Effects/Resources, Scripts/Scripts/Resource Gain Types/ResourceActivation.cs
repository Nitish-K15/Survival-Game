using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AquariusMax.UPF
{
public class ResourceActivation : MonoBehaviour {

	public GameObject objectToBuild;
	public GameObject buildEffect;
	//public Transform spawnBuildEffect;
	public bool isBuilt = false;
	public bool canBuild = true;


	[HideInInspector]
	public bool hasResources = true;

	[Header ("Resource Costs")]
	public int goldCost = 10;
	public int woodCost = 10;
	public int stoneCost = 10;

	void Start ()
	{
		canBuild = true;
		isBuilt = false;
		objectToBuild.SetActive (false);
	}

	public void BuildObject()
	{
		if (PlayerResources.Stone < stoneCost && PlayerResources.Wood < woodCost && PlayerResources.Gold < goldCost)
		{
			Debug.Log ("Not enough resources to build!");
			hasResources = false;
			canBuild = false;
			return;
		}

		if (PlayerResources.Stone >= stoneCost && PlayerResources.Wood >= woodCost && PlayerResources.Gold >= goldCost && isBuilt == false)
		{
			hasResources = true;

			GameObject effect = (GameObject)Instantiate(buildEffect, transform.position, Quaternion.identity);
			Destroy(effect, 3f);

			PlayerResources.Stone -= stoneCost;
			PlayerResources.Wood -= woodCost;
			PlayerResources.Gold -= goldCost;

			isBuilt = true;
			canBuild = false;
			objectToBuild.SetActive (true);
		}
	}
}
}
