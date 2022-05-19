using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AquariusMax.UPF
{
public class MiningScript : MonoBehaviour {

	//This works to play a particle effect in a specific area when wanted.
	//public ParticleSystem effect;

	GameObject selectedRock;
	//public GameObject[] theStump;
	public int rockHealth = 24;
	public int stoneGained = 4;
	private bool isBroken = false;
	public GameObject deathEffect;

	private void Start ()
	{
		//selectedRock = transform.parent.gameObject;
		selectedRock = gameObject;
	}

	private void Update ()
	{
		if (rockHealth <= 0 && isBroken == false)
		{
			//Rigidbody rb = selectedRock.AddComponent<Rigidbody> ();
			//rb.mass = 14;
			//rb.isKinematic = false;
			//rb.useGravity = true;
			//rb.AddForce (Vector3.forward, ForceMode.Impulse);
			StartCoroutine(destroyRock());
			isBroken = true;
		}
	}

	private IEnumerator destroyRock ()
	{
		//When the rock gets destroyed it will play the particle system wherever it is in the scene.
		//effect.Play (true);


		yield return new WaitForSeconds (0);
		Destroy (selectedRock);
		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 3f);
		Debug.Log("You've Gained" + stoneGained + "Stone");
		PlayerResources.Stone += stoneGained;
		//Destroy (theStump);
	}
}
}