using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public Inventory inventory;
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
            {
                IInventory item = eventData.pointerDrag.gameObject.GetComponent<ItemDragHandler>().item;
                if (!item.isWeapon)
                {
                    inventory.RemoveItem(item);
                    item.OnDrop();
                }
            }
        }
    }

}
