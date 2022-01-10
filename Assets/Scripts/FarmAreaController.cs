using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmAreaController : MonoBehaviour
{

    static FarmAreaController instance;
    static Tilemap farmArea;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This allows the game to constantly monitor the Farm Area and run all 
    // necessary scripts inside the farm while the charater is in/out of the area.
    void Instantiate()
    {
        // Unity Singleton Design Pattern
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
