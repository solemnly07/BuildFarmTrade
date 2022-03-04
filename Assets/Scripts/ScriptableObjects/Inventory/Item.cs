using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType{
    Food,
    Tool,
    Seed,
    Machine,    // Smelter, Furnace, etc.
    Container,  // Chests, Drawer, etc.
    Gift,
    Quest,
    Default
}

public class Item : ScriptableObject
{
    public int ItemID;
    public string ItemName;
    public ItemType ItemType;
    [Space]
    public Sprite ItemIcon;
    public Sprite GameSprite;
    [Space]
    public int MaxCount;

    public virtual void UseItem()
    {
        Debug.Log("Item Used: " + ItemName);
    }

}
