using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    public Inventory inventory;
    public void OnItemClicked()
    {
        ItemDragHandler dragHandler = gameObject.transform.GetComponentInChildren<ItemDragHandler>();

        IInventory item = dragHandler.item;

        Debug.Log(item.Name);

        inventory.UseItem(item);

        item.OnUse();
    }
}
