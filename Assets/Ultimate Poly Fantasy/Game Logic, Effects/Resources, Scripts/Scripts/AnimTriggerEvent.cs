using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AquariusMax.Demo
{
	[RequireComponent(typeof(Animator))]
	public class AnimTriggerEvent : MonoBehaviour
	{

		public bool isOpen = true;

		Animator anim;

		private void Awake()
		{
			anim = GetComponent<Animator>();
		}

		private void Start()
		{
			bool currentState = anim.GetBool("isOpen");

			if (currentState != isOpen)
			{
				anim.SetBool("isOpen", isOpen);
			}
		}

		public void OnTriggerEnter()
		{
			anim.SetTrigger("activate");

			isOpen = true;
		}

		public void OnTriggerExit()
		{
			anim.SetTrigger("activate");

			isOpen = !isOpen;
		}
	}
}