using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleDivUI : MonoBehaviour
{
    public Item item;
    public Inventory inventory;
    [SerializeField]
    TextMeshProUGUI TextUI;
    [SerializeField]
    int quantity;

    public void Start()
    {
        quantity = inventory.InventoryDict[item.itemName];
    }

    public void Update()
    {
        quantity = inventory.InventoryDict[item.itemName];
        TextUI.text = $"x{quantity}";
    }
}
