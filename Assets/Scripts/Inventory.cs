using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int slots = 9;

    private List<InventorySlot> mSlots = new List<InventorySlot>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public event EventHandler<InventoryEventArgs> ItemUsed;

    public Inventory()
    {
        for(int i = 0;i < slots;i++)
        {
            mSlots.Add(new InventorySlot(i));
        }
    }

    private InventorySlot FindStackableSlot(IInventory item)
    {
        foreach(InventorySlot slot in mSlots)
        {
            if (slot.IsStackable(item))
                return slot;
        }
        return null;
    }

    private InventorySlot FindNextEmptySlot()
    {
        foreach(InventorySlot slot in mSlots)
        {
            if (slot.IsEmpty)
                return slot;
        }
        return null;
    }
    public void AddItem(IInventory item)
    {
        InventorySlot freeSlot = FindStackableSlot(item);
        if(freeSlot == null)
        {
            freeSlot = FindNextEmptySlot();
        }
        if(freeSlot != null)
        {
                freeSlot.AddItem(item);
                if( ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
        }
        //if(mItems.Count < slots)
        //{
        //    Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
        //    if(collider.enabled)
        //    {
        //        collider.enabled = false;
        //        mItems.Add(item);
        //        item.OnPickup();

        //        if(ItemAdded!=null)
        //        {
        //            ItemAdded(this, new InventoryEventArgs(item));
        //        }
        //    }
        //}
    }

    internal void UseItem(IInventory item)
    {
        if(ItemUsed != null)
        {
            ItemUsed(this, new InventoryEventArgs(item));
        }
    }

    public void RemoveItem(IInventory item)
    {
        foreach(InventorySlot slot in mSlots)
        {
            if(slot.Remove(item))
            {
                if(ItemRemoved!=null)
                {
                    ItemRemoved(this, new InventoryEventArgs(item));
                }
                break;
            }
        }
        //if(mItems.Contains(item))
        //{
        //    mItems.Remove(item);

        //    item.OnDrop();

        //    if(ItemRemoved!=null)
        //    {
        //        ItemRemoved(this, new InventoryEventArgs(item));
        //    }
        //}
    }
}
