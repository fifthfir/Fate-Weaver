using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Basic Inventory")]
public class BasicInventory : ScriptableObject
{
    [SerializeField]
    public List<Item> itemList = new List<Item>();

    [SerializeField]
    public Dictionary<string, int> InventoryDict = new Dictionary<string,int>();

    [SerializeField]
    public List<Item> itemNumList = new List<Item>();

    public void AddItem(Item item)
    {
        if (!itemList.Contains(item))
        {
            itemList.Add(item);
        }
        
        if (InventoryDict.ContainsKey(item.itemName))
        {
            InventoryDict[item.itemName] += 1;
        }
        else
        {
            InventoryDict.Add(item.itemName, 1);
        }

        InventoryController.RefreshItem();

        Debug.Log($"{item.itemName}:{InventoryDict[item.itemName]}");
    }
    
    public bool UseItem(Item item)
    {
        //TODO check cases, item enum to decided what happens when item is useds
        if (InventoryDict.ContainsKey(item.itemName))
        {
            InventoryDict[item.itemName] -= 1;
            if (InventoryDict[item.itemName] == 0)
            {
                itemList.Remove(item);
            }
            return true;
        }

        InventoryController.RefreshItem();

        return false;
    }

    

}


