using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    private bool isCollected;
	private bool isInRange;
	public bool isFlower;
    public Item currItem;
    public PlayerInventory inventory;
	public KeyCode pickupKey = KeyCode.E;
	public GameObject pickupEffect;

	// Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if ((Input.GetKeyDown(pickupKey) || Input.GetButtonDown("PickUp")) && !isCollected && isInRange)
        {
            isCollected = true;
			Destroy(gameObject);
            //inventory.AddItem(currItem.itemName, currItem);
			// Instantiate(pickupEffect, transform.position, transform.rotation);
			//Debug.Log("Item collected!");
            EventBus.Publish(new ItemPickUpEvent(currItem.itemName, currItem));
        }
    }

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
			isInRange = true;
		}

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
    }
}

public class ItemPickUpEvent{
    public string itemName;
    public Item item;
    public ItemPickUpEvent(string _name, Item _item)
    {
        itemName = _name;
        item = _item;
    }
}
