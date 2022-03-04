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
    public int itemCount;

    // For Drag & Drop Only
    static InventorySlot sdrItemSlot; // Sending Item Slot
    static InventorySlot rcvItemSlot; // Receiving Item Slot
    static int overflowAmount;

    static Item itemDragged;
    static int itemDraggedCount;
    Vector3 initialPosition;
    Transform thisParent;
    Transform otherParent;

    


    static bool isItemDropped;

    private void OnValidate()
    {
        RefreshUI();
    }

    private void Awake()
    {
        RefreshUI();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left || eventData.button == PointerEventData.InputButton.Right)
        {
            initialPosition = transform.position;
            thisParent = transform.parent;
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        _LBDrag(eventData);

    }

    public void OnDrag(PointerEventData eventData)
    {
        thisParent.SetAsLastSibling();
        _LOnDrag(eventData);
    }

    public void OnDrop(PointerEventData eventData)
    {
        _LDrop(eventData);
        RefreshUI();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("OnEndDrag");
        _LEDrag(eventData);
        RefreshUI();
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void RefreshUI()
    {
        if (gameObject.GetComponent<Image>())
        {
            if (item == null)
                gameObject.GetComponent<Image>().sprite = empty;
            if (item != null)
                gameObject.GetComponent<Image>().sprite = item.ItemIcon;
        }
    }

    #region Left Button Drag

    // Drag & Drop
    private void _LBDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (this.item != null)
            {
                sdrItemSlot = this;
                Debug.Log("SENDER: " + sdrItemSlot.gameObject.name);
            }
        }
    }

    private void _LDrop(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (sdrItemSlot != null && sdrItemSlot.item != null)
            {
                rcvItemSlot = this;
                isItemDropped = AddItem(sdrItemSlot, rcvItemSlot);

            }
        }
        RefreshUI();
    }

    private void _LEDrag(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ResetSlot();
        }
    }

    private void _LOnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (sdrItemSlot != null)
            {
                sdrItemSlot.transform.position = eventData.position;
            }
        }
    }


    // END
    #endregion


    public bool _IsEmpty(InventorySlot slot)
    {
        // Check if the Receiving Slot is not Empty
        if (slot.item != null)
            return false;
        else
            return true;
    }

    public bool _IsItemExist(InventorySlot sender, InventorySlot receiver)
    {
        // Check if the Item Exists in a Non-Empty Slot
        if (sender.item == receiver.item)
            return true;
        else
            return false;
    }

    public bool _IsSlotFull(InventorySlot slot)
    {
        // Check if
        if (slot.itemCount < slot.item.MaxCount)
            return false;
        else
            return true;
    }

    public int _IsOverflow(InventorySlot sender, InventorySlot receiver)
    {
        int of_chk_amt = ((sender.itemCount + receiver.itemCount) - receiver.item.MaxCount);

        // Check if Item Count will overflow
        // If the Value is Negative, it does not overflow.
        // If the Value is Positive, the value overflows
        // overflow amount will be returned to the Sending Slot
        if (of_chk_amt <= 0)
            return 0;
        else
            return Mathf.Abs(of_chk_amt);
    }

    public bool AddItem(InventorySlot sender, InventorySlot receiver)
    {
        if (!_IsEmpty(receiver))
        {
            if (_IsItemExist(sender, receiver))
            {
                if (!_IsSlotFull(receiver))
                {
                    overflowAmount = _IsOverflow(sender, receiver);

                    if (overflowAmount <= 0)
                    {
                        receiver.item = sender.item;
                        receiver.itemCount = receiver.itemCount + sender.itemCount;
                        return true;
                    }
                    else
                    {
                        receiver.item = sender.item;
                        receiver.itemCount = receiver.item.MaxCount;
                        return true;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }
        else
        {
            receiver.item = sender.item;
            receiver.itemCount = sender.itemCount;
            return true;
        }
    }


    public InventorySlot PickUpCheck(InventorySlot sender)
    {
        if (!_IsEmpty(this))
        {
            if (_IsItemExist(sender, this))
            {
                if (_IsSlotFull(this))
                {
                    // Debug.Log(this.gameObject.name + " is FULL");
                    return null;
                }
                else
                {
                    // Debug.Log(this.gameObject.name + " is NOT FULL");
                    return this;
                }
            }
            else
            {
                // Debug.Log(this.gameObject.name + " is NOT THIS ITEM");
                return null;
            }

        }
        else
        {
            // Debug.Log(this.gameObject.name + " is EMPTY");
            return this;
        }

    }

    public void PickUpItem(InventorySlot sender)
    {
        this.item = sender.item;
        this.itemCount += sender.itemCount;
        RefreshUI();
    }

    public void ResetSlot()
    {
        sdrItemSlot.transform.position = initialPosition;
        if (rcvItemSlot != null)
        {
            // Item is Dropped without Overflow;
            if (isItemDropped && overflowAmount > 0)
            {
                // Debug.Log("Dropped without overflow: " + rcvItemSlot.gameObject.name);
                itemCount = overflowAmount;
            }
            // Item is Dropped with Overflow
            else if (isItemDropped && overflowAmount <= 0)
            {
                // Debug.Log("Dropped with overflow: " + rcvItemSlot.gameObject.name);
                item = null;
                itemCount = 0;
            }

            overflowAmount = 0;
            sdrItemSlot = null;
            rcvItemSlot = null;
        }
    }

    public void ConvertSlot(InventorySlot slot)
    {
        this.item = slot.item;
        this.itemCount = slot.itemCount;
        RefreshUI();
    }

   
}