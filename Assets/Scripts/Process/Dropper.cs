using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public static Dropper instance;
    public GameObject itemToDrop;
    public Transform tablePosition;

    void Awake()
    {
        instance = this;
    }

    public void ToDrop(Item item)
    {
        itemToDrop.SetActive(true);
        StartCoroutine(Drop(item));
    }
        
    public IEnumerator Drop(Item item)
    {
        itemToDrop.GetComponent<SpriteRenderer>().sprite = item.icon;
        itemToDrop.name = item.itemName;
        
        float duration = 0.5f;
        Vector3 startPosition = itemToDrop.transform.position;
        Vector3 endPosition = tablePosition.position;
        float elapsed = 0;

        while (elapsed < duration)
        {
            itemToDrop.transform.position = Vector3.Lerp(startPosition, endPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        itemToDrop.transform.position = endPosition;
    }
}
