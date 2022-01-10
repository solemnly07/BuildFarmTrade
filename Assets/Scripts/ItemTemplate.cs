using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTemplate : MonoBehaviour
{
    [SerializeField]
    GameObject objectToPlace;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateTemplate();
        PlaceObject();
    }

    

    void CreateTemplate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(mousePos.x),Mathf.Round(mousePos.y));
    }

    void PlaceObject()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(objectToPlace, transform.position, Quaternion.identity);
        }
    }
}
