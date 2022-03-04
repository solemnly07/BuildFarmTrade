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

    public void UseItem()
    {
        Debug.Log("TYPE: " + this.item.GetType().ToString());
        itemCount = itemCount - 1;
    }

}
