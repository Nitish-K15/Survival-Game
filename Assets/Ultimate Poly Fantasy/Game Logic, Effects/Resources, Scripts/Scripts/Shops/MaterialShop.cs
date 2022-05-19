using System;
using UnityEngine;
namespace AquariusMax.UPF
{
public enum MaterialUnit { Sword, Axe, Dagger, Mace, Staff, Shield, Bow }
//public enum WeaponElement { None, Fire, Water, Air, Earth, Spirit, Holy, Dark, Poison }
//public enum WeaponBuff {none, defenseUp, attackSpeedUp, healthUp, damageUp, staminaUp }

[Serializable]
public class Materials {

	public string materialName;
	public int cost = 10;
	public int sellPrice = 5;
//	public WeaponUnit typeOfWeapon;
//	public WeaponElement element;
//	public WeaponBuff buff;
}

public class MaterialShop : MonoBehaviour {

	//public Ingredient weaponResult;
	public Materials[] materialsToBuy;
}
}