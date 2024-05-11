using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// A NPC profile parent class
/// </summary>
[CreateAssetMenu(fileName = "New NPC Profile", menuName = "NPC/NPCProfile")]
public class NPCProfile : ScriptableObject
{
    public string npcName;
    public Color sigilColor;
    public NPCType npcType;
    public string description;
    public Sprite npcPortrait;
    [Header("NPC Dialogue Settings")]
    [Tooltip("A list of TextAsset representing the NPC dialogue sequence")]
    public List<TextAsset> DialogueSequence;
}

public enum NPCType
{
    Default,
    Important
}
