using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item item;
    public ItemController<Item> itemNumber;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        CreateInventory();
    }

    // Update is called once per frame
    public void CreateInventory()
    {
        itemNumber = new ItemController<Item>();
    }

    public int GetOwnedQuantity()
    {
        return item.ownedQuantity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            itemNumber.AddItem(new Item("Item", 1));
            counter = item.ownedQuantity + 1;
            Debug.Log($"You now have {item.ownedQuantity} items in your inventory");
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            itemNumber.UseItem("Item");
            Debug.Log($"You now have {item.ownedQuantity} items in your inventory");
        }
    }
}
