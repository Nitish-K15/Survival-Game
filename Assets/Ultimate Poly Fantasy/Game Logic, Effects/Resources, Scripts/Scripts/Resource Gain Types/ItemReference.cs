using UnityEngine;
namespace AquariusMax.UPF
{
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemReference : ScriptableObject {

	new public string name = "New Item";
	public Sprite icon = null;
	public bool isDefaultItem = false;

}
}
