using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A SimpleDivObject parent class
/// </summary>
[CreateAssetMenu(fileName = "New SimpleDivItem", menuName = "Divination/SimpleDivItem")]
public class SimpleDivItem : ScriptableObject
{
    public string itemName;
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
