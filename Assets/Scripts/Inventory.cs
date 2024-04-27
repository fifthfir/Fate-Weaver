using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Subscription <ItemPickUpEvent> item_pick_up_event_subscription;
    public List<Item> itemList = new List<Item>();
    public Dictionary<string, int> InventoryDict = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        item_pick_up_event_subscription = EventBus.Subscribe<ItemPickUpEvent>(OnPickUp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// pickupevent call back, updates player Inventory
    /// </summary>
    /// <param name="e"></param>
    void OnPickUp(ItemPickUpEvent e)
    {
        if (!itemList.Contains(e.item))
        {
            itemList.Add(e.item);
            InventoryDict[e.itemName] = 1;
        }
        else
        {
            InventoryDict[e.itemName] += 1;
        }
        Debug.Log($"{e.itemName}: {InventoryDict[e.itemName]}");
    }
}
