using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AquariusMax.UPF
{
public class Inventory : MonoBehaviour {



	public static Inventory instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one Inventory Instance found in your scene!");
			return;
		}

		instance = this;
	}



	public delegate void OnItemChanged ();
	public OnItemChanged onItemChangedCallback;

	public int space = 20;

	public List<ItemReference> items = new List<ItemReference>();

	public bool Add (ItemReference item)
	{
		if (!item.isDefaultItem)
		{
			if (items.Count >= space)
			{
				Debug.Log("Not enough room!");
				return false;
			}

			items.Add (item);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke ();
		}

		return true;
	}

	public void Remove (ItemReference item)
	{
		items.Remove (item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke ();
	}
}
}