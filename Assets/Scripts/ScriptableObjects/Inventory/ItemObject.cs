using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    [SerializeField]
    Item item;


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


}
