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

    public void AddItem(Item item)
    {
        Debug.Log("Add item");
        if (!itemList.Contains(item) && !InventoryDict.ContainsKey(item.itemName))
        {
            Debug.Log("Add new");
            itemList.Add(item);
            InventoryDict.Add(item.itemName, 1);
            // InventoryController.CreateNewItem(item);
        }
        else
        {
            InventoryDict[item.itemName] += 1;
            Debug.Log("Add old");
        }

        InventoryController.RefreshItem();

        Debug.Log($"{item.itemName}:{InventoryDict[item.itemName]}");
    }

}


