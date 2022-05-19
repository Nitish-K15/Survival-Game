using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace AquariusMax.UPF
{
public class GoldUI : MonoBehaviour {

	public Text goldText;

	// Update is called once per frame
	void Update () {
		goldText.text = "" + PlayerResources.Gold.ToString();
	}
}
}
