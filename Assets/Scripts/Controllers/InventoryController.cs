using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    public GameObject inventoryObject;
    // [SerializeReference]
    // public Inventory inventory;

    void Awake()
    {
        inventoryObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Instantiate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ToggleInventory();
    }

    public void ToggleInventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryObject.activeSelf)
                inventoryObject.SetActive(false);
            else
                inventoryObject.SetActive(true);

            TimeController.GetInstance().ToggleTimeFlow();
                
        }
    }

}
