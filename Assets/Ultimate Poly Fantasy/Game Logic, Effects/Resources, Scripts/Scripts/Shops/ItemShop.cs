using System;
using UnityEngine;
namespace AquariusMax.UPF
{
public enum ItemUnit { Sword, Axe, Dagger, Mace, Staff, Shield, Bow }
public enum ItemEffect { None, Fire, Water, Air, Earth, Spirit, Holy, Dark, Poison }
public enum ItemBuff {none, defenseUp, attackSpeedUp, healthUp, damageUp, staminaUp }

[Serializable]
public class Items {

	public string itemName;
	public int cost = 10;
	public int sellPrice = 5;
	public ItemUnit typeOfItem;
	public ItemEffect element;
	public ItemBuff buff;
}

public class ItemShop : MonoBehaviour {

	//public Ingredient weaponResult;
	public Items itemsToBuy;
}
}