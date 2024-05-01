using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    [SerializeField]
    public List<Item> itemList = new List<Item>();
    public Dictionary<string, int> InventoryDict = new Dictionary<string,int>();

    public void AddItem(string itemName, Item item)
    {
      
        if (!itemList.Contains(item) && !InventoryDict.ContainsKey(itemName))
        {
            itemList.Add(item);
            InventoryDict[itemName] = 1;
        }

        {
            InventoryDict[itemName] += 1;
           
        }

        Debug.Log($"{itemName}:{InventoryDict[itemName]}");
    }

}


