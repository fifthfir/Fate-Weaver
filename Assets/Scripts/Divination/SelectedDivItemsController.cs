using UnityEngine;
using UnityEngine.UI;

public class SelectedDivItemsController : MonoBehaviour
{
    Subscription<SimpleDivItemSelectionEvent> simple_div_item_selection_event;
    public GameObject selectedDivItemIconPrefab;

    [Header("private variables")]
    [SerializeField]
    private Item primary_item;
    [SerializeField]
    private GameObject primary_icon;
    [SerializeField]
    private Item secondary_item;
    [SerializeField]
    private GameObject secondary_icon;
    // Start is called before the first frame update
    void Start()
    {
        simple_div_item_selection_event = EventBus.Subscribe<SimpleDivItemSelectionEvent>(OnItemSelection);
    }

    void OnItemSelection(SimpleDivItemSelectionEvent e)
    {
        //TODO refacotr
        // two functions
        // create icon
        // remove icon
        //

        Debug.Log($"{e.item.itemName} of {e.item.itemType} selected for dinivation");
        if (e.item.itemType == ItemType.PrimaryDivItem)
        {
            if (this.transform.childCount == 0) // if primary div item selected for the first time -> spawn in primary icon
            {
                selectedDivItemIconPrefab.GetComponent<Image>().sprite = e.item.icon;
                primary_icon = Instantiate(selectedDivItemIconPrefab, this.transform);
                primary_icon.transform.parent = this.transform;
            }

            else if(primary_icon != null)
            {
                    primary_icon.GetComponent<Image>().sprite = e.item.icon;
            }
        }

      
        else if(e.item.itemType == ItemType.SecondaryDivItem)
        {
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

    void CreateIcon(GameObject icon, Item item)
    {
        //TODO
    }
}
