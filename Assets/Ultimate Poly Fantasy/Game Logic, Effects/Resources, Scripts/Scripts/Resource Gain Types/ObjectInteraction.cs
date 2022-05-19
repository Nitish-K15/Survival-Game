using UnityEngine;

namespace AquariusMax.UPF
{
public class ObjectInteraction : MonoBehaviour {

	public float radius = 3f;
	public Transform interactionTransform;

	bool isFocus = false;
	public Transform player;

	bool hasInteracted = false;

	public virtual void Interact ()
	{
		// this method is meant to be overwritten
		Debug.Log("Interacting With" + transform.name);
	}

	void Update ()
	{
		if (isFocus && !hasInteracted)
		{
			float distance = Vector3.Distance (player.position, interactionTransform.position);
			if (distance <= radius)
			{
				Interact ();
				hasInteracted = true;
			}
		}
	}

	public void OnFocused (Transform playerTransform)
	{
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	}

	public void OnDefocused ()
	{
		isFocus = false;
		player = null;
		hasInteracted = false;
	}

	void OnDrawGizmosSelected ()
	{
		if (interactionTransform == null)
		{
			interactionTransform = transform;
		}

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (interactionTransform.position, radius);
	}
}
}
