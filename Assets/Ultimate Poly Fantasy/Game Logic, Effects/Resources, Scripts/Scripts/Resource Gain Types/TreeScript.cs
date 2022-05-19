using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AquariusMax.UPF
{
public class TreeScript : MonoBehaviour {

	GameObject selectedTree;
	public Transform leafEffectPos;
	public GameObject theStump;
	public int treeHealth = 14;
	public int woodGained = 10;
	private bool isFalling = false;
	public GameObject leafEffect;
	public GameObject deathEffect;

	private void Start ()
	{
		//selectedTree = transform.parent.gameObject;
		selectedTree = this.gameObject;
	}

	private void Update ()
	{
		if (treeHealth <= 0 && isFalling == false)
		{
			GameObject leafeffect = (GameObject)Instantiate(leafEffect, leafEffectPos.position, Quaternion.identity);
			Destroy(leafeffect, 7f);
			Rigidbody rb = selectedTree.AddComponent<Rigidbody> ();
			rb.mass = 10;
			rb.isKinematic = false;
			rb.useGravity = true;
			rb.AddForce (Vector3.forward, ForceMode.Impulse);
			StartCoroutine(destroyTree());
			isFalling = true;
		}
	}

	private IEnumerator destroyTree ()
	{

		yield return new WaitForSeconds (7);
		Destroy (selectedTree);
		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 3f);
		Destroy (theStump);
		Debug.Log("You've Gained" +  woodGained + "Wood");
		PlayerResources.Wood += woodGained;
	}
}
}