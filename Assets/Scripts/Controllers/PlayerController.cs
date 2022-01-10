using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Cinemachine;

public class PlayerController : MonoBehaviour
{

    static PlayerController instance;


    Rigidbody2D player;

    // Movement
    float horizontal;
    float vertical;

    public float speed;
    public float lookDistance;

    GameObject timebox;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DefineControls();
        PlayerActions();

    }

    void FixedUpdate()
    {
        Move();
    }


    float xDirection;
    float yDirection;
    Vector2 lookDirection;

    void DefineControls()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        if (horizontal != 0 || vertical != 0)
        {
            xDirection = horizontal;
            yDirection = vertical;
            // Debug.Log("X: " + xDirection + ", Y: " + yDirection);
        }
    }

    void Move()
    {
        if (TimeController.GetInstance().IsTimeFlow())
        {
            Vector2 position = player.position;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                position.x = position.x + ((speed * 3) * horizontal * Time.deltaTime);
                position.y = position.y + ((speed * 3) * vertical * Time.deltaTime);
            }
            else
            {
                position.x = position.x + (speed * horizontal * Time.deltaTime);
                position.y = position.y + (speed * vertical * Time.deltaTime);
            }

            player.MovePosition(position);
        }
    }

    float xDir = 0;
    float yDir = 0;
    void SetLookDirection()
    {

        if (xDirection < 0)
            xDir = -1;
        else if (xDirection > 0)
            xDir = 1;
        else
            xDir = 0;


        if (yDirection < 0)
            yDir = -1;
        else if (yDirection > 0)
            yDir = 1;
        else
            yDir = 0;

        lookDirection = new Vector2(xDir, yDir);
    }

    void PlayerActions()
    {
        // Toggle Time Flow
        if (Input.GetKeyDown(KeyCode.C))
        {
            TimeController.GetInstance().ToggleTimeFlow();
        }


    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        ItemObject item = other.GetComponent<ItemObject>();
        
        if(item != null)
        {
            if(InventoryController.GetInstance().AddItem(item.GetItem()))
                Destroy(item.gameObject);
            
        }

    }

}
