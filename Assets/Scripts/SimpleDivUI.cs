using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SimpleDivUI : MonoBehaviour
{
    [Header("Public variables (Edit)")]
    public Item item;
    public Inventory inventory;
    public TextMeshProUGUI resultText;

    [Header("Private variables (Don't Edit)")]
    [SerializeField]
    private TextMeshProUGUI quantity_ui;
    [SerializeField]
    private int quantity;
    [SerializeField]
    private bool hasItem = false;
    [SerializeField]
    private Button curr_button;


    public void Start()
    {
        quantity_ui = GetComponentInChildren<TextMeshProUGUI>();
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

        quantity_ui.text = $"x{quantity}";

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
