using System;
using UnityEngine;
namespace AquariusMax.UPF
{
public enum ArmorUnit { Helm, Chest, Shoulders, Bracers, Gloves, Pants, Legs, Boots }
public enum ArmorElement { None, Fire, Water, Air, Earth, Spirit, Holy, Dark, Poison }
public enum ArmorClass {Light, Heavy, Medium }
public enum ArmorBuff {none, defenseUp, speedUp, healthUp, damageUp, staminaUp }

[Serializable]
public class Armor {

	public string armorName;
	public int cost = 10;
	public int sellPrice = 5;
	public ArmorUnit typeOfArmor;
	public ArmorClass armorClass;
	public ArmorElement element;
	public ArmorBuff buff;

}

public class ArmorShop : MonoBehaviour {

	//public Ingredient weaponResult;
	public Armor[] armorToBuy;
}
}
