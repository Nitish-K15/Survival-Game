using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AquariusMax.UPF
{
public class PickaxeAction : MonoBehaviour {

	Animator pickaxeAnim;

	void Start()
	{
		pickaxeAnim = gameObject.GetComponent<Animator>();
	}
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			pickaxeAnim.SetTrigger("Active");
		}
	}
}
}
