using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AquariusMax.UPF
{
public class TreeSimpleScript : MonoBehaviour {

	GameObject selectedTree;
	public int treeHealth = 5;
	public int woodGained = 3;
	private bool isChopped = false;
	public GameObject deathEffect;

	private void Start ()
	{
		//selectedTree = transform.parent.gameObject;
		selectedTree = this.gameObject;
	}

	private void Update ()
	{
		if (treeHealth <= 0 && isChopped == false)
		{
			isChopped = true;
			Destroy (selectedTree);
			GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
			Destroy(effect, 3f);
			PlayerResources.Wood += woodGained;
		}
	}
}
}
