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
    public GameObject inventoryPanel;
    IInventory item;

    private void Awake()
    {
        inventory.ItemUsed += Inventory_ItemUsed;
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    private void Start()
    {
        weaponSlotManager.LoadWeaponOnSlot(weapon, false);
    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        //IInventory item = e.Item;
        //GameObject goItem = (item as MonoBehaviour).gameObject;
        //goItem.SetActive(true);

        //goItem.transform.parent = hand.transform;
        //goItem.transform.localPosition = Vector3.zero;
        if (e.Item.isWeapon)
        {
            weapon = e.Item.objectItem;
            weaponSlotManager.LoadWeaponOnSlot(e.Item.objectItem, false);
        }

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
