using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D playerCollider;
    Animator animator;

    GameManager gameManager;



    [Header("GameObjects")]
    [SerializeField] private PlayerFeet feet;
    [SerializeField] private PlayerLadderTrigger playerLadderTrigger;

    [Header("Variables")]
    [SerializeField] private int playerID = 0;
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float _playerGravityScale = 10f;
    [SerializeField] private float playerGravityScale = 10f;
    private Vector2 moveInput;

    [Header("Bools")]
    [SerializeField] private bool playerActive = true;
    [SerializeField] public bool canMove = true;
    [SerializeField] private bool isOverLadder = false;
    [SerializeField] private bool isOverSwitch = false;
    [SerializeField] private bool isFeetTouchingGround = false;
    [SerializeField] private bool playerHasHorizontalSpeed;
    [SerializeField] private bool playerIsClimbing;
    [SerializeField] private bool pressedSwap;

    [Header("Animation")]
    public bool animalking = false;
    public bool animIdle = true;
    public bool animClimbing = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {

    }

    private void OnEnable()
    {
        print(gameObject.name);
        moveInput = Vector2.zero;
        //rb.velocity = Vector2.zero;
    }

    void Update()
    {
        rb.gravityScale = playerGravityScale;
        isOverLadder = playerLadderTrigger.GetLadderCheck();
        isOverSwitch = playerLadderTrigger.GetSwitchCheck();
        playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        playerIsClimbing = (Mathf.Abs(rb.velocity.y) > Mathf.Epsilon) && isOverLadder;

        Run();
        IsOnLadderCheck();
        IsOnGroundCheck();
        AnimationChecks();
        //Debug.Log(rb.velocity);
    }

    void OnMove(InputValue value)
    {
        if (canMove)
        {
            moveInput = value.Get<Vector2>();
        }
        else
        {
            return;
        }
    }

    void OnSwap()
    {
        gameManager.ChangeLayer();
        gameManager.SetPlayerActiveStatus();
    }


    void Run()
    {

        if (isOverLadder)
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
        if (playerHasHorizontalSpeed && !playerIsClimbing)
        {
            animator.SetBool("isWalking", true);
            if (rb.velocity.x > 0)
            {
                //transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x), 1f);
                transform.localScale = new Vector2(1f, 1f);
            }
            else if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector2(-1f, 1f);
            }

        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (playerIsClimbing)
        {
            animator.SetBool("isClimbing", true);
        }
        else
        {
            animator.SetBool("isClimbing", false);
        }
    }

    private void IsOnLadderCheck()
    {
        if (isOverLadder)
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