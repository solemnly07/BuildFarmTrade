using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public int ItemID;
    public string ItemName;
    [Space]
    public Sprite ItemIcon;
    public Sprite GameSprite;
    [Space]
    public int MaxCount;

}
