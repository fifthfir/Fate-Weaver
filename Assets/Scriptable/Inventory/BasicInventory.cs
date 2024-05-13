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
    public List<int> itemNumList = new List<int>();

    public void Clear()
    {
        itemList = new List<Item>();
        InventoryDict = new Dictionary<string,int>();
        itemNumList = new List<int>();
    }
    
    public void AddItem(Item item)
    {
        if (!itemList.Contains(item))
        {
            itemList.Add(item);
            itemNumList.Add(1);
        } else {
            itemNumList[itemList.IndexOf(item)]++;
        }

        
        // if (InventoryDict.ContainsKey(item.itemName))
        // {
        //     InventoryDict[item.itemName] += 1;
        //     itemNumList[itemList.IndexOf(item)]++;
        // }
        // else
        // {
        //     InventoryDict.Add(item.itemName, 1);
        // }

        InventoryController.RefreshItem();

        Debug.Log($"{item.itemName}:{itemNumList[itemList.IndexOf(item)]}");
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


