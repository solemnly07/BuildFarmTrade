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
        Debug.Log(inventorySlots[0].item.ItemName);
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


    public bool AddItem(Item item)
    {
        bool itemAdded = AvailableSlot(toolSlots, item) ? true : AvailableSlot(inventorySlots, item);
        return itemAdded;
    }

    private bool AvailableSlot(InventorySlot[] slots, Item item)
    {
        InventorySlot availableSlot = null;
        bool itemAdded = false;

        for (int i = 0; i < slots.Length; i++)
        {
            availableSlot = slots[i];
            if (availableSlot != null)
            {
                if (availableSlot.DoesItemExist(item) && !availableSlot.IsSlotFull())
                {
                    itemAdded = availableSlot.AddItem(item);
                    break;
                }
                else if (availableSlot.item == null)
                {
                    itemAdded = availableSlot.AddItem(item);
                    break;
                }
            }
        }
        return itemAdded;
    }

    // public bool AvailableToolSlot(Item item)
    // {
    //     InventorySlot availableSlot = null;
    //     bool itemAdded = false;

    //     for (int i = 0; i < toolSlots.Length; i++)
    //     {
    //         availableSlot = toolSlots[i];
    //         if (availableSlot != null)
    //         {
    //             if(availableSlot.DoesItemExist(item) && !availableSlot.IsSlotFull())
    //             {
    //                 itemAdded = availableSlot.AddItem(item);
    //                 break;
    //             }

    //             if(availableSlot.item == null)
    //             {
    //                 itemAdded = availableSlot.AddItem(item);
    //                 break;
    //             }
    //         }
    //     }
    //     return itemAdded;
    // }

    // public bool AvailableInventorySlot(Item item)
    // {
    //     InventorySlot availableSlot = null;
    //     bool itemAdded = false;

    //     for (int i = 0; i < toolSlots.Length; i++)
    //     {
    //         availableSlot = toolSlots[i];
    //         if (availableSlot != null)
    //         {
    //             if(availableSlot.DoesItemExist(item) && !availableSlot.IsSlotFull())
    //             {
    //                 itemAdded = availableSlot.AddItem(item);
    //                 break;
    //             }
    //         }
    //     }

    //     return itemAdded;
    // }

    // public void GetAvailableSlot(Item item)
    // {
    //     InventorySlot availableSlot = null;
    //     bool itemAdded = false;

    //     for (int i = 0; i < toolSlots.Length; i++)
    //     {
    //         availableSlot = toolSlots[i];
    //         if (availableSlot != null)
    //         {
    //             if(availableSlot.DoesItemExist(item) && !availableSlot.IsSlotFull())
    //             {
    //                 itemAdded = availableSlot.AddItem(item);
    //                 break;
    //             }
    //         }
    //     }

    //     if(!itemAdded)
    //     {

    //     }
    // }




}
