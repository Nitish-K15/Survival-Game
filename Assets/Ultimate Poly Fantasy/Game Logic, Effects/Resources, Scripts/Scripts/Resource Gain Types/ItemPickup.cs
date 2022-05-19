using UnityEngine;
namespace AquariusMax.UPF
{
public class ItemPickup : ObjectInteraction {

	public ItemReference item;

	public override void Interact()
	{
		base.Interact ();
		PickUp ();
	}

	void PickUp ()
	{
		Debug.Log ("Picking up" + item.name);
		Destroy (gameObject);
	}
}
}