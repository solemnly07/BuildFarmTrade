using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMenuController : MonoBehaviour
{
    public static PlayerMenuController instance;
    bool isMenuActive;

    // Start is called before the first frame update
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

    public bool GetActive()
    {
        return isMenuActive;
    }

    // Update is called once per frame
    void Update()
    {
        //ToggleMenu("sc_player_land");
    }

    public void ToggleMenu(string sceneName)
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (isMenuActive)
            {
                isMenuActive = false;
                SceneLoader.LoadScene(sceneName);
                TimeController.GetInstance().ToggleTimeFlow();
                ToolbarController.SetActive(true);
                
            }
            else
            {
                isMenuActive = true;
                SceneLoader.LoadScene("sc_player_menu");
                TimeController.GetInstance().ToggleTimeFlow();
                ToolbarController.SetActive(false);
            }
        }
    }
}


// creditcardservice@unionbankph.com
// 2 Valid 
// 3 Specimen Signatures
// 02-8841-8600
