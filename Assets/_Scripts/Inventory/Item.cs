using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public string itemName;
    public int ownedQuantity;

    public virtual void Use()
    {
        ownedQuantity -= 1;
        //Insert item removal code here (removing an item from the inventory list).
    }

    public Item(string name, int quantity = 0)
    {
        itemName = name;
        ownedQuantity = quantity;
    }
}
