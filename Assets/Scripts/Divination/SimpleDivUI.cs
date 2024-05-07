using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SimpleDivUI : MonoBehaviour
{
    [Header("Public variables (Edit)")]
    public Item currItem;
    public Inventory inventory;
    public TextMeshProUGUI resultText;
    public SimpleDivControl divControl;
    public TextMeshProUGUI quantityUI;

    [Header("Private variables (Do Not Edit)")]
    [SerializeField]
    private int quantity;
    [SerializeField]
    private bool hasItem = false;
    [SerializeField]
    private Button curr_button;


    public void Start()
    {
        curr_button = GetComponent<Button>();

    }

    public void Update()
    {

        if (inventory.itemList.Contains(currItem))
        {

            if (quantity > 0)
            {
                hasItem = true;
            }
            else
            {
                hasItem = false;
            }
            quantity = inventory.InventoryDict[currItem.itemName];
            quantityUI.text = $"x{quantity}";
    
        }

        curr_button.interactable = hasItem;
      
    }

    public void SelectItem()
    {
        if (currItem.itemType == ItemType.PrimaryDivItem)
        {
            divControl.primaryDivItem = currItem;
        }

        if (currItem.itemType == ItemType.SecondaryDivItem)
        {
            divControl.secondaryDivItem = currItem;
        }
        // publish item selection event
        EventBus.Publish(new SimpleDivItemSelectionEvent(currItem));
    }

    public void UseItem()
    {
        if (inventory.UseItem(currItem.itemName))
        {
            //TODO publish simpleDivitem selected event upon usage for later confirmation
                resultText.text = currItem.divResult;
        }
        StopAllCoroutines();
        StartCoroutine(ClearTextAfter(5f));
    }

    public IEnumerator ClearTextAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        resultText.text = "";
    }
}


