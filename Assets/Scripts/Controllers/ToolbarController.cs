using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    ToolbarController instance;
    [SerializeField]
    List<GameObject> toolSlots;
    [SerializeField]
    GameObject selector;
    bool isEmpty;

    static GameObject currentToolSlot;

    static bool isActive;




    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

        if (toolSlots.Count > 0)
            isEmpty = false;

        if (currentToolSlot == null)
        {
            // Debug.Log("Current Slot is Null on Start");
        }
        else
        {
            // Debug.Log("Current Slot is not Null on Start");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEmpty)
        {
            if (!PlayerMenuController.GetInstance().GetActive())
                MoveSelector();
        }
    }

    public static void SetActive(bool condition)
    {
        isActive = condition;
    }

    public static bool GetActive()
    {
        return isActive;
    }

    public GameObject GetCurrentToolSlot()
    {
        return currentToolSlot;
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
}
