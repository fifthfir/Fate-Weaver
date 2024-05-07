using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedDivItemsController : MonoBehaviour
{
    Subscription<SimpleDivItemSelectionEvent> simple_div_item_selection_event;
    public GameObject selectedDivItemIconPrefab;
    public GameObject secondaryDivView;
    public TextMeshProUGUI divResult;

    [Header("Private Variables")]
    [SerializeField]
    private Item primary_item;
    [SerializeField]
    private GameObject primary_icon;
    [SerializeField]
    private Item secondary_item;
    [SerializeField]
    private GameObject secondary_icon;
    [SerializeField]
    private Button[] secondary_buttons;
    [SerializeField]
    private Inventory player_inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        simple_div_item_selection_event = EventBus.Subscribe<SimpleDivItemSelectionEvent>(OnItemSelection);
        secondary_buttons = secondaryDivView.GetComponentsInChildren<Button>();
        player_inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        
    }

    void OnItemSelection(SimpleDivItemSelectionEvent e)
    {
        //TODO refacotr
        // two functions
        // create icon
        // remove icon
        foreach(Button secondary_button in secondary_buttons)
        {
            HideSecondaryButtons(secondary_button);
        }

        Debug.Log($"{e.item.itemName} of {e.item.itemType} selected for dinivation");
        if (e.item.itemType == ItemType.PrimaryDivItem)
        {
            primary_item = e.item;
            if (this.transform.childCount == 0) // if primary div item selected for the first time -> spawn in primary icon
            {
                selectedDivItemIconPrefab.GetComponent<Image>().sprite = e.item.icon;
                primary_icon = Instantiate(selectedDivItemIconPrefab, this.transform);
                primary_icon.transform.parent = this.transform;
            }

            else if (this.transform.childCount == 1)
            {
                    primary_icon.GetComponent<Image>().sprite = e.item.icon;
            }

            if (!secondaryDivView.activeSelf)
            {
                secondaryDivView.SetActive(true);
            }

            // get associated secondary div items
            if (primary_item.associatedDivItems.Count != 0)
            {
                int index = 0;
                foreach (Item associated_item in primary_item.associatedDivItems)
                {
                    Button curr_button = secondary_buttons[index];
                    ShowSecondaryButton(curr_button, associated_item);
                    index++;
                }
            }
        }

      
        else if(e.item.itemType == ItemType.SecondaryDivItem)
        {
            secondary_item = e.item;
            if(this.transform.childCount == 1)   // if secondary div item selected for the first time -> spawn in secondary icon 
            {
                selectedDivItemIconPrefab.GetComponent<Image>().sprite = e.item.icon;
                secondary_icon = Instantiate(selectedDivItemIconPrefab, this.transform);
                secondary_icon.transform.parent = this.transform;
            }

            else if(this.transform.childCount == 2)
            {
                secondary_icon.GetComponent<Image>().sprite = e.item.icon;
            }
        }
    }

    public void ShowSecondaryButton(Button button,Item associated_item )
    {
        Image curr_image = button.GetComponent<Image>();
  
        TextMeshProUGUI quantity_text = button.GetComponentInChildren<TextMeshProUGUI>();
        quantity_text.enabled = true;
        curr_image.sprite = associated_item.icon;
        button.GetComponent<SimpleDivUI>().currItem = associated_item;
        Debug.Log($"associated item:{associated_item}, curr item:{button.GetComponent<SimpleDivUI>().currItem}");
        curr_image.enabled = true;
        button.enabled = true;
    }

    public void HideSecondaryButtons(Button button)
    {
        Image curr_image = button.GetComponent<Image>();
        TextMeshProUGUI quantity_text = button.GetComponentInChildren<TextMeshProUGUI>();
        quantity_text.enabled = false;
        curr_image.enabled = false;
        button.enabled = false;
    }

    public void ResetSelection()
    {
        primary_item = null;
        secondary_item = null;
        if (primary_icon != null)
        {
            Destroy(primary_icon);
        }

        if (secondary_icon != null)
        {
            Destroy(secondary_icon);
        }

        foreach (Button button in secondary_buttons)
        {
            HideSecondaryButtons(button);
        }
    }


    public void StartsDivination()
    {
        if(primary_item != null)
        {
            player_inventory.UseItem(primary_item.itemName);
            primary_item = null;
            DestroyImmediate(primary_icon, true);
        }

        if(secondary_item != null)
        {
            player_inventory.UseItem(secondary_item.itemName);
            secondary_item = null;
            DestroyImmediate(secondary_icon, true);
        }

        if (this.transform.childCount == 1)
        {
            divResult.text = primary_item.divResult;
        }
        else
        {

            divResult.text = " This is a temp placeholder text";
        }
       
       
        StartCoroutine(eraseText(3f));

        EventBus.Publish(new DivinationStartsEvent());
    }

    IEnumerator eraseText(float duration)
    {
        yield return new WaitForSeconds(duration);
        divResult.text = "";
    }
}
