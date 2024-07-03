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

    public void ItemOnClicked() 
    {
        InventoryController.UpdateOnClick(slotItem);
    }

    public void ItemOnDivined() 
    {
        Debug.Log("click");
        InventoryController.instance.UpdateToDrop(slotItem);
        Dropper.instance.ToDrop(slotItem);
    }

}
