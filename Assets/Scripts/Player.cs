using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D playerCollider;
    Animator animator;

    [Header("GameObjects")]
    [SerializeField] private PlayerFeet feet;
    [SerializeField] private PlayerLadderTrigger playerLadderTrigger;

    [Header("Variables")]
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float _playerGravityScale = 10f;
    [SerializeField] private float playerGravityScale = 10f;
    private Vector2 moveInput;
    
    [Header("Bools")]
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool isOverLadder = false;
    [SerializeField] private bool isFeetTouchingGround = false;
    public bool playerHasHorizontalSpeed; //Cutscene i�in eri?ebilmek i�in de?i?tirildi.
    
    [Header("Animation")]
    public bool animalking = false;
    public bool animIdle = true;
    public bool animClimbing = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        rb.gravityScale = playerGravityScale;
        isOverLadder = playerLadderTrigger.GetLadderCheck();
        playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        Run();
        IsOnLadderCheck();
        IsOnGroundCheck();
        AnimationChecks();
        Debug.Log(rb.velocity);
    }

    void OnMove(InputValue value)
    {
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

    void AnimationChecks()
    {
        if(playerHasHorizontalSpeed)
        {
            animator.SetBool("isWalking", true);
            if(rb.velocity.x > 0)
            {
                //transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x), 1f);
                transform.localScale = new Vector2 (1f, 1f);
            }
            else if(rb.velocity.x < 0)
            {
                transform.localScale = new Vector2 (-1f, 1f);
            }
            
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void IsOnLadderCheck()
    {
        if(isOverLadder)
        {
            //Debug.Log("over ladder");
            playerGravityScale = 0;
        }
        else
        {
            playerGravityScale = _playerGravityScale;
        }
    }

    private void IsOnGroundCheck()
    {
        isFeetTouchingGround = feet.GetGroundCheck();
    }
    
    public void SetRigidBodyGravityScale(float inputVal)
    {
        playerGravityScale = inputVal;
    }

    public float GetDefaultGravityScale()
    {
        return _playerGravityScale;
    }

}
