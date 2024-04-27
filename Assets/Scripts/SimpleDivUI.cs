using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SimpleDivUI : MonoBehaviour
{
    public Item item;
    public Inventory inventory;
    [SerializeField]
    TextMeshProUGUI TextUI;
    [SerializeField]
    int quantity;
    [SerializeField]
    bool hasItem = false;
    [SerializeField]
    Button curr_button;
    public TextMeshProUGUI resultText;

    public void Start()
    {
        TextUI = GetComponentInChildren<TextMeshProUGUI>();
        //quantity = inventory.InventoryDict[item.itemName];
        curr_button = GetComponent<Button>();
    }

    public void Update()
    {
        if (inventory.itemList.Contains(item))
        {
            quantity = inventory.InventoryDict[item.itemName];
            if(quantity > 0)
            {
                hasItem = true;
            }
            else
            {
                hasItem = false;
            }
        }

        TextUI.text = $"x{quantity}";

        curr_button.interactable = hasItem;
        
    }

    public void UseItem()
    {
        inventory.UseItem(item.itemName);
        resultText.text = item.divResult;
        StopAllCoroutines();
        StartCoroutine(ClearTextAfter(5f));
    }

    public IEnumerator ClearTextAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        resultText.text = "";
    }
}
