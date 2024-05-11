using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// A NPC profile parent class
/// </summary>
[CreateAssetMenu(fileName = "New NPC Info", menuName = "NPC/NPCInfo")]
public class NPCInfo : ScriptableObject
{
    public string infoDescription;
    public Color sigilColor;
}
