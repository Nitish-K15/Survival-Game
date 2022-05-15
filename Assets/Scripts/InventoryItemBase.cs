using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour,IInventory
{
    public virtual string Name
    {
        get
        {
            return "base_item";
        }
    }

    public Sprite _image = null;

    public virtual void OnUse()
    {

    }

    public Sprite image
    {
        get
        {
            return _image;
        }
    }

    public InventorySlot Slot { get; set; }

    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnDrop()
    {
        Destroy(gameObject);
    }
}
