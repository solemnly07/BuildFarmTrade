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
    }

    void Awake()
    {
        Instantiate();
        setDefaultToolSlot();
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
    }

    public void setDefaultToolSlot()
    {
        if (toolSlots.Length > 0 && currentToolSlot != null)
        {
            selector.transform.position = toolSlots[0].transform.position;
            currentToolSlot = toolSlots[0];
        }
    }


    void MoveSelector()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selector.transform.position = toolSlots[0].transform.position;
            currentToolSlot = toolSlots[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selector.transform.position = toolSlots[1].transform.position;
            currentToolSlot = toolSlots[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selector.transform.position = toolSlots[2].transform.position;
            currentToolSlot = toolSlots[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selector.transform.position = toolSlots[3].transform.position;
            currentToolSlot = toolSlots[3];
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selector.transform.position = toolSlots[4].transform.position;
            currentToolSlot = toolSlots[4];
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selector.transform.position = toolSlots[5].transform.position;
            currentToolSlot = toolSlots[5];
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selector.transform.position = toolSlots[6].transform.position;
            currentToolSlot = toolSlots[6];
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            selector.transform.position = toolSlots[7].transform.position;
            currentToolSlot = toolSlots[7];
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            selector.transform.position = toolSlots[8].transform.position;
            currentToolSlot = toolSlots[8];
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            selector.transform.position = toolSlots[9].transform.position;
            currentToolSlot = toolSlots[9];
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
            while (j < toolSlots.Length)
            {
                placeholderSlot = toolSlots[j].PickUpCheck(pickedUpItem);
                if(placeholderSlot != null)
                availableSlots.Add(placeholderSlot);
                j++;
            }

            int i = 0;
            while (i < inventorySlots.Length)
            {
                placeholderSlot = inventorySlots[i].PickUpCheck(pickedUpItem);
                if(placeholderSlot != null)
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

}
