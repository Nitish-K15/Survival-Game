using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum TypeOfItem { Gold, Wood, Stone, Tool, Potion, Weapon, Material }
public enum TypeOfItemBuff { none, defenseUp, attackSpeedUp, healthUp, damageUp, elementUp, staminaUp, Healing, speedBoost, expUp }

[Serializable]
public class ItemPickups {

	public string itemName;
	//public int cost = 10;
	public int worth = 5;
	public TypeOfItem typeOfItem;
	public TypeOfItemBuff typeOfBuff;
}
*/
namespace AquariusMax.UPF
{
public class ItemScript : MonoBehaviour {

	//public ItemReference item;
//	public ItemPickups itemStats;

	GameObject selectedItem;
	//public GameObject chestToDestroy;
	[HideInInspector]
	public int clicksToPickup = 1;
	public int goldGainedOnPickup = 1;
	public int woodGainedOnPickup = 1;
	public int stoneGainedOnPickup = 1;
	private bool pickUp = false;
	//public GameObject deathEffect;

	private void Start ()
	{
		//selectedItem = transform.parent.gameObject;
		selectedItem = this.gameObject;
	}

	private void Update ()
	{
		if (clicksToPickup <= 0 && pickUp == false)
		{
			StartCoroutine(destroyItem());
			pickUp = true;
		}
	}

	private IEnumerator destroyItem ()
	{

		//bool wasPickedUp = Inventory.instance.Add (item);
		Debug.Log("You've Gained" +  goldGainedOnPickup + "Gold");
		PlayerResources.Gold += goldGainedOnPickup;
		Debug.Log("You've Gained" +  woodGainedOnPickup + "Wood");
		PlayerResources.Wood += woodGainedOnPickup;
		Debug.Log("You've Gained" +  stoneGainedOnPickup + "Stone");
		PlayerResources.Stone += stoneGainedOnPickup;

		yield return new WaitForSeconds (0);
		Debug.Log ("Picking up" + tag);

		//if (wasPickedUp)
		Destroy (selectedItem);
		//GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		//Destroy(effect, 3f);
		//Destroy (chestToDestroy);
	}
}
}
