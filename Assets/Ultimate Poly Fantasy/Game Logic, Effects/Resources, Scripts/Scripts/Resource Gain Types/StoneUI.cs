using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace AquariusMax.UPF
{
public class StoneUI : MonoBehaviour {

	public Text stoneText;

	// Update is called once per frame
	void Update () {
		stoneText.text = "" + PlayerResources.Stone.ToString();
	}
}
}