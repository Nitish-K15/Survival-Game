using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public Inventory inventory;
    public Transform inventoryPanel;

    private void Start()
    {
        inventory.ItemAdded += InventoryScript_ItemAdded;
        inventory.ItemRemoved += Inventory_ItemRemoved;
        inventoryPanel = transform.Find("InventoryPanel");
    }

    private void InventoryScript_ItemAdded(object sender,InventoryEventArgs e)
    {
        int index = -1;
       foreach(Transform slot in inventoryPanel)
        {
            index++;
            Image image = slot.GetChild(0).GetComponent<Image>();
            ItemDragHandler itemDragHandler = image.transform.GetComponent<ItemDragHandler>();
            Text txtCount = slot.GetChild(1).GetComponent<Text>();

            if(index == e.Item.Slot.Id)
            {
                image.enabled = true;
                image.sprite = e.Item.image;

                int itemCount = e.Item.Slot.Count;
                if (itemCount > 1)
                    txtCount.text = itemCount.ToString();
                else
                    txtCount.text = "";

                itemDragHandler.item = e.Item;

                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender,InventoryEventArgs e)
    {
        int index = -1;
        foreach(Transform slot in inventoryPanel)
        {
            index++;
            Image image = slot.GetChild(0).GetComponent<Image>();
            ItemDragHandler itemDragHandler = image.transform.GetComponent<ItemDragHandler>();
            Text txtCount = slot.GetChild(1).GetComponent<Text>();
            if (itemDragHandler.item == null)
                continue;
            if (e.Item.Slot.Id == index)
            {
                int itemCount = e.Item.Slot.Count;
                itemDragHandler.item = e.Item.Slot.FirstItem;

                if(itemCount < 2)
                {
                    txtCount.text = "";
                }

                else
                {
                    txtCount.text = itemCount.ToString();
                }

                if(itemCount == 0)
                {
                    image.enabled = false;
                    image.sprite = null;
                }

                break;
            }
        }
    }
}
