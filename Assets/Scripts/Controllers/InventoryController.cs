using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour
{

    static InventoryController instance;

    [SerializeField]
    Transform inventoryParent;
    [SerializeField]
    InventorySlot[] inventorySlots;
    [Space]
    [SerializeField]
    Transform toolParent;
    [SerializeField]
    InventorySlot[] toolSlots;
    [SerializeField]
    Transform toolWorldParent;
    [SerializeField]
    InventorySlot[] toolWorldSlots;
    [Space]
    [SerializeField]
    GameObject selector;
    [SerializeField]
    static InventorySlot currentToolSlot;
    [SerializeField]
    InventorySlot pickedUpItem;

    private void OnValidate()
    {
        if (inventoryParent != null)
            inventorySlots = inventoryParent.GetComponentsInChildren<InventorySlot>();

        if (toolParent != null)
            toolSlots = toolParent.GetComponentsInChildren<InventorySlot>();

        if (toolWorldParent != null)
            toolWorldSlots = toolWorldParent.GetComponentsInChildren<InventorySlot>();
    }

    void Awake()
    {
        Instantiate();
    }

    void Start()
    {
        // Debug.Log(inventorySlots[0].item.ItemName);
    }

    void Instantiate()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public static InventoryController GetInstance()
    {
        return instance;
    }

    void Update()
    {
        if (!PlayerMenuController.GetInstance().IsMenuActive())
        {
            MoveSelector();
        }

        UseCurrentItem();
    }

    void UseCurrentItem()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentToolSlot == null)
                setDefaultToolSlot(toolWorldSlots[0]);

            Item itemHeld = currentToolSlot != null ? currentToolSlot.item : null;
            if (itemHeld != null)
            {
                switch (itemHeld.ItemType)
                {
                    case ItemType.Food:
                        var food = (FoodItem)itemHeld;
                        food.UseItem();
                        break;
                    case ItemType.Tool:
                        var tool = (ToolItem)itemHeld;
                        tool.UseItem();
                        break;
                    default:
                        itemHeld.UseItem();
                        break;
                }
            }
        }

    }

    public void setDefaultToolSlot(InventorySlot slot)
    {
        selector.transform.position = slot.transform.position;
        currentToolSlot = slot;
    }


    void MoveSelector()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selector.transform.position = toolWorldSlots[0].transform.position;
            currentToolSlot = toolWorldSlots[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selector.transform.position = toolWorldSlots[1].transform.position;
            currentToolSlot = toolWorldSlots[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selector.transform.position = toolWorldSlots[2].transform.position;
            currentToolSlot = toolWorldSlots[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selector.transform.position = toolWorldSlots[3].transform.position;
            currentToolSlot = toolWorldSlots[3];
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selector.transform.position = toolWorldSlots[4].transform.position;
            currentToolSlot = toolWorldSlots[4];
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selector.transform.position = toolWorldSlots[5].transform.position;
            currentToolSlot = toolWorldSlots[5];
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selector.transform.position = toolWorldSlots[6].transform.position;
            currentToolSlot = toolWorldSlots[6];
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            selector.transform.position = toolWorldSlots[7].transform.position;
            currentToolSlot = toolWorldSlots[7];
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            selector.transform.position = toolWorldSlots[8].transform.position;
            currentToolSlot = toolWorldSlots[8];
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            selector.transform.position = toolWorldSlots[9].transform.position;
            currentToolSlot = toolWorldSlots[9];
        }
    }


    public bool PickUpItem(ItemObject item)
    {
        if (pickedUpItem != null)
        {
            pickedUpItem.item = item.GetItem();
            pickedUpItem.itemCount = item.itemCount;


            InventorySlot placeholderSlot = null;
            List<InventorySlot> availableSlots = new List<InventorySlot>();
            // Check if the Item is in Inventory First;

            int j = 0;
            while (j < toolWorldSlots.Length)
            {
                placeholderSlot = toolWorldSlots[j].PickUpCheck(pickedUpItem);
                if (placeholderSlot != null)
                    availableSlots.Add(placeholderSlot);
                j++;
            }

            int i = 0;
            while (i < inventorySlots.Length)
            {
                placeholderSlot = inventorySlots[i].PickUpCheck(pickedUpItem);
                if (placeholderSlot != null)
                    availableSlots.Add(placeholderSlot);
                i++;
            }

            availableSlots[0].PickUpItem(pickedUpItem);
            // Debug.Log("ADDED IN THIS SLOT: " + availableSlots[0].gameObject.name);
            return true;
        }
        else
            return false;
    }


    // This is to copy the items inside the Toolbar from the Menu
    public void UpdateToolbarWorld()
    {
        int i = 0;
        if (toolWorldSlots.Length > 0 && toolSlots.Length > 0)
        {
            Debug.Log("Updating the World Toolbar");
            for (; i < toolWorldSlots.Length; i++)
            {
                toolWorldSlots[i].ConvertSlot(toolSlots[i]);
            }
        }
    }

    public void UpdateToolbarMenu()
    {
        int i = 0;
        if (toolWorldSlots.Length > 0 && toolSlots.Length > 0)
        {
            Debug.Log("Updating the Menu Toolbar");
            for (; i < toolSlots.Length; i++)
            {
                toolSlots[i].ConvertSlot(toolWorldSlots[i]);
            }
        }
    }


}
