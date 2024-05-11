using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Event for picking up an item
/// </summary>
public class ItemPickUpEvent
{
    public string itemName;
    public Item item;
    public ItemPickUpEvent(string _name, Item _item)
    {
        itemName = _name;
        item = _item;
    }
}

public class SimpleDivItemSelectionEvent
{
    public Item item;
    public SimpleDivItemSelectionEvent(Item _item)
    {
        item = _item;
    }
}

public class DivinationStartsEvent
{
    public DivinationStartsEvent() { }
}

public class MiniGamePerfectEvent
{
    public MiniGamePerfectEvent() { }
}

public class MiniGameHitEvent
{
    public MiniGameHitEvent() { }
}

public class MiniGameFailEvent
{
    public MiniGameFailEvent() { }
}