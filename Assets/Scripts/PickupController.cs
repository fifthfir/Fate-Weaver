using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    private bool isCollected;
	public bool isFlower;

	public KeyCode pickupKey = KeyCode.E;

	// Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if ((Input.GetKeyDown(pickupKey) || Input.GetButtonDown("PickUp")) && !isCollected)
        {
            TryPickup();
        }
    }

    private void TryPickup()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("pickups") && isFlower)
            {
                CollectItem(collider.gameObject);
                break;
            }
        }
    }

    private void CollectItem(GameObject item)
    {
        item.GetComponent<PickupController>().isCollected = true;
        Destroy(item);
        Debug.Log("Item collected!");
    }
}
