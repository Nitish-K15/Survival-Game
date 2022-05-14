using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IInventory
{
    public string Name
    {
        get
        {
            return "Sword";
        }
    }

    public Sprite _image = null;

    public Sprite image
    {
        get
        {
            return _image;
        }
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }
}
