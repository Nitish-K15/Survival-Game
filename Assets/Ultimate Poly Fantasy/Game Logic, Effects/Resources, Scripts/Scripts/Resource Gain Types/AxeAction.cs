using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AquariusMax.UPF
{
public class AxeAction : MonoBehaviour {

	Animator axeAnim;
	public float choppingSpeed = 1f;
	private float choppingCooldown = 0f;

	void Start()
	{
		axeAnim = gameObject.GetComponent<Animator>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			axeAnim.SetTrigger ("Active");
			//choppingCooldown = 1f / choppingSpeed;
		}
	}
}
}
