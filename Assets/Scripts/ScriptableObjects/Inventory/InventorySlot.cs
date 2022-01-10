using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerDownHandler
{
    [SerializeField]
    Sprite empty;

    public Item item;

    static Item itemDragged;
    Vector3 initialPosition;

    static bool isItemDropped;

    private void OnValidate() {
        RefreshUI();
    }

    private void Awake() {
        RefreshUI();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        initialPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("OnBeginDrag");
        if (item != null)
        {
            itemDragged = item;
            Debug.Log("Item Dragged: " + itemDragged.ItemName);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (itemDragged != null)
        {
            transform.position = eventData.position;
        }

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropping On: " + this.name);
        if (item == null)
        {
            this.item = itemDragged;
            isItemDropped = true;
            Debug.Log("Item Dropped: " + this.item.ItemName);
        }
        else
        {
            Debug.Log("Cannot Drop Here, Occupied by: " + this.item.ItemName);
        }
        RefreshUI();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("OnEndDrag");
        transform.position = initialPosition;
        if (isItemDropped)
        {
            itemDragged = null;
            item = null;
            isItemDropped = false;
        }
        RefreshUI();
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void RefreshUI()
    {
        if (item == null)
            gameObject.GetComponent<Image>().sprite = empty;
        if (item != null)
            gameObject.GetComponent<Image>().sprite = item.ItemIcon;
    }




}