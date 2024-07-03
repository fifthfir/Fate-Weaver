using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public BasicInventory slotInventory;
    public Text description;

    public void Start()
    {
        if (description)
        {
            description.text = slotItem.itemDescription;
        }
    }

    public void ItemOnClicked() 
    {
        InventoryController.UpdateOnClick(slotItem);
    }

    public void ItemOnDivined() 
    {
        Debug.Log("click");
        InventoryController.instance.UpdateToDrop(slotItem);
        Dropper.instance.ToDrop(slotItem);
        InventoryController.instance.inventory.UseItem(slotItem);
    }

}
