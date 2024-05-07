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
    [TextArea]
    public string description;
    public Sprite overworldSprite;
    public Sprite icon;
    public string divResult;
    public int collectSFX;
    // public AudioClip collectSFX;
    /* possible properties
    public GameObject divVFX;
    public AudioClip divSFX;
    public GameObject collectVFX;
    */
    /// Add additional properties and methods
}

public enum ItemType
{
    SimpleDivItem,
    CraftItem
    //TODO add more
}
