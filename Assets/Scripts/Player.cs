using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("GameObjects")]
    [SerializeField] private GameObject feet;

    [Header("Variables")]
    [SerializeField] private float playerSpeed;
    private Vector2 moveInput;
    
    [Header("Bools")]
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool isOverLadder = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        Debug.Log("on move start");
        if(canMove)
        {
            moveInput = value.Get<Vector2>();
        }
        else
        {
            return;
        }
    }

    void Run()
    {
        
        
        if(isOverLadder)
        {
            Vector2 playerVelocity = new Vector2(0, moveInput.y * playerSpeed);
            rb.velocity = playerVelocity;
        }
        else
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, rb.velocity.y);
            rb.velocity = playerVelocity;
        }
    }

}
