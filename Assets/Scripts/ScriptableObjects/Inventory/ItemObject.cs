using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    [SerializeField]
    Item item;
    [SerializeField]
    public int itemCount;

    private void OnValidate()
    {
        if (item != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = item.GameSprite;
            gameObject.name = item.ItemName;
        }
    }

    public Item GetItem()
    {
        return item;
    }

    public int GetItemCount()
    {
        return itemCount;
    }

    public void SetItemCount(int num)
    {
        itemCount = num;
    }

}
