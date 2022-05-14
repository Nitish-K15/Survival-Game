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
        inventoryPanel = transform.Find("InventoryPanel");
    }

    private void InventoryScript_ItemAdded(object sender,InventoryEventArgs e)
    {
       foreach(Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();

            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.image;

                break;
            }
        }
    }
}
