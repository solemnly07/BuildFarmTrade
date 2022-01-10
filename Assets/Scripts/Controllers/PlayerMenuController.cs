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

    void Awake()
    {
        PlayerMenuTab.SetActive(false);
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
                isMenuActive = false;
            }
            else
            {
                PlayerMenuTab.SetActive(true);
                isMenuActive = true;
            }
            
            TimeController.GetInstance().ToggleTimeFlow();

        }
    }
}

