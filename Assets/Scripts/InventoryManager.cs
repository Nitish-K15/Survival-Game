using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    WeaponSlotManager weaponSlotManager;
    public GameObject hand;
    public WeaponItem weapon;
    IInventory item;

    private void Start()
    {
        inventory.ItemUsed += Inventory_ItemUsed;
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        //IInventory item = e.Item;
        //GameObject goItem = (item as MonoBehaviour).gameObject;
        //goItem.SetActive(true);

        //goItem.transform.parent = hand.transform;
        //goItem.transform.localPosition = Vector3.zero;
        weapon = e.Item.objectItem;
        weaponSlotManager.LoadWeaponOnSlot(e.Item.objectItem, false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        item = collision.collider.GetComponent<IInventory>();
        if(item != null)
        {
            inventory.AddItem(item);
        }
    }
}
