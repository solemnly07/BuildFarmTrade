using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<Item> items;
    [SerializeField]
    Transform itemParent;
    [SerializeField]
    public InventorySlot[] itemSlots;

    private void OnValidate()
    {
        if (itemParent != null)
        {
            itemSlots = itemParent.GetComponentsInChildren<InventorySlot>();
        }
        RefreshUI();
    }

    private void RefreshUI()
    {
        int i = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].item = items[i];
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].item = null;
        }
    }
}
