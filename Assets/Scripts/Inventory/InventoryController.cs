using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryController : MonoBehaviour
{
    public static InventoryController instance;
    public BasicInventory inventory;
    public Chest chest;

    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInformation;

    public static bool isChesting = false;

    void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "test";
    }

    public static void UpdateOnClick(Item item)
    {
        if (isChesting)
        {
            instance.inventory.UseItem(item);
            instance.chest.AddItem(item);
        }
        else 
        {
            instance.itemInformation.text = item.itemDescription;
        }
    }

    public void UpdateToDrop(Item item)
    {
        gameObject.SetActive(false);
    }

    public static void CreateNewItem(Item item)
    {
        
        Debug.Log(item.name);

        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotInventory = instance.inventory;
        newItem.slotImage.sprite = item.icon;
        newItem.slotNum.text = instance.inventory.itemNumList[instance.inventory.itemList.IndexOf(item)].ToString();
    }

    public static void RefreshItem()
    {
        // Debug.Log("Refresh");

        if (instance.slotGrid) {
            for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
            {
                if (instance.slotGrid.transform.childCount <= 0)
                {
                    break;
                }
                Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            }
        }
        

        for (int i = 0; i < instance.inventory.itemList.Count; i++)
        {
            Debug.Log(instance.inventory.itemList.Count);
            CreateNewItem(instance.inventory.itemList[i]);
        }
    }
}
