using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
   string Name { get; }
   Sprite image { get; }

    bool isWeapon { get; }

    public WeaponItem objectItem { get; }

    void OnPickup();

    void OnDrop();
    void OnUse();

    InventorySlot Slot { get; set; }
}

public class InventoryEventArgs: EventArgs
{
    public InventoryEventArgs(IInventory item)
    {
        Item = item;
    }

    public IInventory Item;
}
