using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D playerCollider;

    [Header("GameObjects")]
    [SerializeField] private GameObject feet;

    [Header("Variables")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerGravityScale = 10f;
    private Vector2 moveInput;
    
    [Header("Bools")]
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool isOverLadder = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
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
            Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, moveInput.y * playerSpeed);
            rb.velocity = playerVelocity;
        }
        else
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, rb.velocity.y);
            rb.velocity = playerVelocity;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ladder 1")
        {
            Debug.Log("over ladder");
            isOverLadder = true;
            rb.gravityScale = 0;
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ladder 1")
        {
            isOverLadder = false;
            rb.gravityScale = playerGravityScale;
        }
    }

}
