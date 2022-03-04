using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMenuController : MonoBehaviour
{
    public static PlayerMenuController instance;
    bool isMenuActive;

    [SerializeField]
    public GameObject PlayerMenuTab;
    [SerializeField]
    GameObject ToolbarWorld;
    [SerializeField]
    GameObject ToolbarSelector;

    void Awake()
    {
        PlayerMenuTab.SetActive(false);
        ToolbarWorld.SetActive(true);
        ToolbarSelector.SetActive(true);
    }

    void Start()
    {
        Instantiate();
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
        isMenuActive = false;
    }


    public static PlayerMenuController GetInstance()
    {
        return instance;
    }

    public bool IsMenuActive()
    {
        return isMenuActive;
    }

    // Update is called once per frame
    void Update()
    {
        ToggleInventory();
    }

    public void ToggleInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (PlayerMenuTab.activeSelf)
            {
                PlayerMenuTab.SetActive(false);
                ToolbarWorld.SetActive(true);
                ToolbarSelector.SetActive(true);
                InventoryController.GetInstance().UpdateToolbarWorld();
                isMenuActive = false;
            }
            else
            {
                PlayerMenuTab.SetActive(true);
                ToolbarWorld.SetActive(false);
                ToolbarSelector.SetActive(false);
                InventoryController.GetInstance().UpdateToolbarMenu();
                isMenuActive = true;
            }
            
            TimeController.GetInstance().ToggleTimeFlow();

        }
    }
}

