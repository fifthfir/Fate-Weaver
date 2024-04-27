using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A SimpleDivObject parent class
/// </summary>
[CreateAssetMenu(fileName = "New Item", menuName = "Collectible/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public string description;
    public Sprite overworldSprite;
    public Sprite icon;
    public GameObject divResult;
    /* possible properties
    public GameObject divVFX;
    public AudioClip divSFX;
    public GameObject collectVFX;
    public AudioClip collectSFX;*/
    /// Add additional properties and methods
}

public enum ItemType
{
    SimpleDivItem,
    CraftItem
    //TODO add more
}
