using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AquariusMax.UPF
{
public class ResourceCollecting : MonoBehaviour {

	[SerializeField]
	Camera cam;

	public float choppingSpeed = 1f;
	private float choppingCooldown = 0f;

	[Header("Tree Chopping")]
	public GameObject axeOfChoice;
	[Header("Mining")]
	public GameObject pickaxeOfChoice;
	private bool axeIsEquipped;
	private bool pickaxeIsEquipped;
	[Header("Focus")]
	public ObjectInteraction focus;

	void Start ()
	{
		if (cam == null)
		{
			cam = Camera.main;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		choppingCooldown -= Time.deltaTime;

		if (!axeOfChoice.activeSelf && Input.GetKeyDown(KeyCode.Alpha1))
		{
			axeIsEquipped = true;
			axeOfChoice.SetActive (true);
			pickaxeOfChoice.SetActive (false);
			pickaxeIsEquipped = false;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			axeIsEquipped = false;
			axeOfChoice.SetActive (false);
		}

		if (!pickaxeOfChoice.activeSelf && Input.GetKeyDown(KeyCode.Alpha2))
		{
			pickaxeIsEquipped = true;
			pickaxeOfChoice.SetActive (true);
			axeOfChoice.SetActive (false);
			axeIsEquipped = false;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			pickaxeIsEquipped = false;
			pickaxeOfChoice.SetActive (false);
		}

		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		RaycastHit hit;

		if (Physics.Raycast (transform.position, fwd, out hit, 7))
		{
			if (hit.collider.GetComponent<Collider> ().tag == "Tree" && axeIsEquipped == true && Input.GetMouseButtonDown (0))
			{
				if (choppingCooldown <= 0f)
				{
					Debug.Log ("Hitting the Tree!");
					//AxeAction axe = gameObject.GetComponent<AxeAction> ();
					//axe.Chop();
					TreeScript treeScript = hit.collider.gameObject.GetComponent<TreeScript> ();
					treeScript.treeHealth--;
					choppingCooldown = 1f / choppingSpeed;
				}
			}

			if (hit.collider.GetComponent<Collider> ().tag == "TreeSimple" && axeIsEquipped == true && Input.GetMouseButtonDown (0))
			{
				TreeSimpleScript treeSimpleScript = hit.collider.gameObject.GetComponent<TreeSimpleScript> ();
				treeSimpleScript.treeHealth--;
			}

			if (hit.collider.GetComponent<Collider> ().tag == "MiningRock" && pickaxeIsEquipped == true && Input.GetMouseButtonDown (0))
			{
				MiningScript rockScript = hit.collider.gameObject.GetComponent<MiningScript> ();
				rockScript.rockHealth--;
			}
/*
			if (Input.GetMouseButtonDown(0))
			{
				ObjectInteraction interactable = hit.collider.gameObject.GetComponent<ObjectInteraction> ();
				if (interactable != null)
				{
					SetFocus (interactable);
				}
			}
			*/

			if (hit.collider.GetComponent<Collider>().tag == "Item" && Input.GetMouseButtonDown(1))
			{ 
				ItemScript interactable = hit.collider.gameObject.GetComponent<ItemScript> ();
				interactable.clicksToPickup--;
				
			}
		}
			
	}
		
	void SetFocus (ObjectInteraction newFocus)
	{

		focus = newFocus;
	}

	void RemoveFocus ()
	{
		focus = null;
	}
}
}
