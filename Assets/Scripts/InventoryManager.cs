using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    IInventory item;
    private void OnCollisionEnter(Collision collision)
    {
        item = collision.collider.GetComponent<IInventory>();
        if(item != null)
        {
            inventory.AddItem(item);
        }
    }
}
