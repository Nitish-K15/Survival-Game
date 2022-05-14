using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
   string Name { get; }
   Sprite image { get; }

    void OnPickup();
}

public class InventoryEventArgs: EventArgs
{
    public InventoryEventArgs(IInventory item)
    {
        Item = item;
    }

    public IInventory Item;
}
