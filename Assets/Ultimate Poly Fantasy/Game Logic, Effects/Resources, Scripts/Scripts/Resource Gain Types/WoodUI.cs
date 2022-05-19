using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace AquariusMax.UPF
{
public class WoodUI : MonoBehaviour {

	public Text woodText;

	// Update is called once per frame
	void Update () {
		woodText.text = "" + PlayerResources.Wood.ToString();
	}
}
}
