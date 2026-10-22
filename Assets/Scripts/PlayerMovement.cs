using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //Reference to other script with the variables & stats
    [SerializeField] private ScriptableStats stats;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D col;

    //Velocity variable to control our velocity before applying it to the rigidbody velocity
    private Vector2 playerVelocity;

    private float time;

    //Input Checks
    private bool jumpDown;
    private bool jumpHeld;
    private Vector2 move;

    private bool isGrounded;

    //Time calculation since player left the ground.
    private float frameLeftGrounded = float.MinValue;

    //The distance it detects the player hitting the roof or ground
    private float grounderDistance = 0.05f;

    [Header("Jump Buffering Variables")]
    private bool jumpToConsume;
    private bool bufferedJumpUsable;
    private bool endedJumpEarly;
    private bool coyoteUsable;
    private float timeJumpWasPressed;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        CheckInput();
    }

    void CheckInput()
    {
        Debug.Log("D pressed: " + Input.GetKey(KeyCode.D));

        jumpDown = Input.GetKeyDown(KeyCode.Space);
        jumpHeld = Input.GetKey(KeyCode.Space);

        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (jumpDown)
        {
            jumpToConsume = true;
            timeJumpWasPressed = time;
        }
    }

    private void FixedUpdate()
    {
        CheckCollisions();

        if (jumpDown || jumpHeld)
        {
            HandleJump();
        }
        HandleDirection();
        HandleGravity();

        ApplyMovement();
    }

    private void CheckCollisions()
    {
        //The '~' symbol means im inverting the layer or excluding it. 
        //This method projects a shape to check if anything touched that shape from any specified direction
        bool hitGround = Physics2D.CapsuleCast(col.bounds.center,
            col.bounds.size,
            col.direction,
            0,
            Vector2.down,
            grounderDistance,
            ~stats.PlayerLayer);

        bool hitRoof = Physics2D.CapsuleCast(col.bounds.center,
            col.bounds.size,
            col.direction,
            0,
            Vector2.up,
            grounderDistance,
            ~stats.PlayerLayer);

        Debug.Log($"Ground hit: {hitGround}, Is grounded: {isGrounded}");

        if (hitRoof)
        {
            playerVelocity.y = Mathf.Min(0,playerVelocity.y);
        }

        if (!isGrounded && hitGround)
        {
            isGrounded = true;
            bufferedJumpUsable = true;
            endedJumpEarly = false;
        }
        else if(isGrounded && !hitGround){
            isGrounded= false;
            frameLeftGrounded = time;
        }
    }

    private bool HasBufferedJump()
    {
        return bufferedJumpUsable && (time < timeJumpWasPressed + stats.jumpBuffer);
    }

    private bool CanUseCoyote()
    {
        return coyoteUsable && !isGrounded && (time < frameLeftGrounded + stats.coyoteTime);
    }

    private void HandleJump()
    {
        //Detects jump ending early when it isnt already true, when the player isnt on the ground, when jump was not held, and when player is moving up
        //This variable is to have shorter jump height when you only press it and dont hold down
        if (!endedJumpEarly && !isGrounded && !jumpHeld && playerVelocity.y > 0) 
        {
            endedJumpEarly = true;
        }

        if (!jumpToConsume && !HasBufferedJump())
        {
            return;
        }

        if (isGrounded || CanUseCoyote())
        {
            ApplyJump();
        }

        jumpToConsume = false;
    }

    private void ApplyJump()
    {
        endedJumpEarly = false;
        timeJumpWasPressed = 0;
        bufferedJumpUsable= false;
        coyoteUsable= false;
        playerVelocity.y = stats.jumpPower;

        Debug.Log("Jump executed!");

        jumpDown = false;
        jumpHeld = false;
    }

    private void HandleDirection()
    {
        if (move.x == 0)
        {
            float deceleration = 0f;
            if (isGrounded)
            {
                deceleration = stats.groundDeceleration;
            }
            else
            {
                deceleration = stats.airDeceleration;
            }

            playerVelocity.x = Mathf.MoveTowards(playerVelocity.x,
                0f,
                deceleration * Time.deltaTime);
        }
        else
        {
            playerVelocity.x = Mathf.MoveTowards(playerVelocity.x,
                move.x * stats.maxSpeed,
                stats.acceleration * Time.deltaTime);
        }
    }
    private void HandleGravity()
    {
        if (isGrounded && playerVelocity.y <= 0f)
        {
            playerVelocity.y = stats.groundingForce;
        }
        else
        {
            var inAirGravity = stats.fallAcceleration;

            if (endedJumpEarly && playerVelocity.y > 0f)
            {
                inAirGravity *= stats.jumpEndedEarlyGravity;
            }

            playerVelocity.y = Mathf.MoveTowards(
                playerVelocity.y,
                -stats.maxFallSpeed,
                inAirGravity * Time.deltaTime
            );
        }
    }
    private void ApplyMovement()
    {
        Debug.Log("Player velocity: " + playerVelocity);
        rb.linearVelocity = playerVelocity;
    }
}

