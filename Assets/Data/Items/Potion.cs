using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : InventoryItemBase
{
    public override string Name
    {
        get
        {
            return "Potion";
        }
    }

    public override void OnUse()
    {
        base.OnUse();
    }
}
