using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot 
{
    public Stack<IInventory> mItemStack = new Stack<IInventory>();

    private int mID = 0;

    public InventorySlot(int id)
    {
        mID = id;
    }

    public int Id
    {
        get { return mID; }
    }

    public void AddItem(IInventory item)
    {
        item.Slot = this;
        mItemStack.Push(item);
    }

    public IInventory FirstItem
    {
        get
        {
            if (IsEmpty)
                return null;

            return mItemStack.Peek();
        }
    }

    public bool IsStackable(IInventory item)
    {
        if (IsEmpty)
            return false;

        IInventory first = mItemStack.Peek();
        if (first.Name == item.Name)
            return true;

        return false;
    }

    public bool IsEmpty
    {
        get { return Count == 0; }
    }

    public int Count
    {
        get { return mItemStack.Count; }
    }

    public bool Remove(IInventory item)
    {
        if (IsEmpty)
            return false;

        IInventory first = mItemStack.Peek();
        if(first.Name == item.Name)
        {
            mItemStack.Pop();
            return true;
        }
        return false;
    }
}
