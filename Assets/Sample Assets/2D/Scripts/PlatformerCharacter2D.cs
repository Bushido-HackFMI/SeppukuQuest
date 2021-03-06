﻿using UnityEngine;

public class PlatformerCharacter2D : MonoBehaviour 
{
	bool facingRight = true;							// For determining which way the player is currently facing.

	public float maxSpeed = 10f;				// The fastest the player can travel in the x axis.
	[SerializeField] float jumpForce = 400f;			// Amount of force added when the player jumps.	

	[Range(0, 1)]
	[SerializeField] float crouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	
	[SerializeField] bool airControl = false;			// Whether or not a player can steer while jumping;
	[SerializeField] LayerMask whatIsGround;			// A mask determining what is ground to the character
    [SerializeField] LayerMask whatIsWall;              // A mask determining what is wall to the character
	
	Transform groundCheck;								// A position marking where to check if the player is grounded.
	float groundedRadius = .2f;							// Radius of the overlap circle to determine if grounded
	bool grounded = false;								// Whether or not the player is grounded.
	Transform ceilingCheck;								// A position marking where to check for ceilings
	float ceilingRadius = .01f;							// Radius of the overlap circle to determine if the player can stand up
	Animator anim;										// Reference to the player's animator component.
    bool doubleJump = false;
    bool touchingWall = false;
    Transform wallCheck;
    float wallTouchRadius = .2f;
    public int stamina = 100;
    float sprintSpeed;
    float staminaSprintTimer;
    bool wallJumped = false;

    public GUIStyle customStyle;
    Vector2 staminaBarPos = new Vector2(56, 180);
    Vector2 staminaBarSize = new Vector2(40, 20);

    public AnimationClip wall;

    void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		ceilingCheck = transform.Find("CeilingCheck");
        wallCheck = transform.Find("WallCheck");
		anim = GetComponent<Animator>();
        sprintSpeed = maxSpeed * 2;
	}

	void FixedUpdate()
	{
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
        touchingWall = Physics2D.OverlapCircle(wallCheck.position, wallTouchRadius, whatIsWall);
        
        if(touchingWall)
        {
            grounded = false;
            doubleJump = false;
        }
		// Set the vertical animation
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
	}

	public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if(!crouch && anim.GetBool("Crouch"))
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if( Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
				crouch = true;
		}

		// Set whether or not the character is crouching in the animator
		anim.SetBool("Crouch", crouch);

		//only control the player if grounded or airControl is turned on
		if(grounded || airControl)
		{
			// Reduce the speed if crouching by the crouchSpeed multiplier
			move = (crouch ? move * crouchSpeed : move);

			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetFloat("Speed", Mathf.Abs(move));

			// Move the character
			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
			
			// If the input is moving the player right and the player is facing left...
			if(move > 0 && !facingRight)
				// ... flip the player.
				Flip();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if(move < 0 && facingRight)
				// ... flip the player.
				Flip();
		}

        // If the player should jump...
        if (grounded && jump) {
            // Add a vertical force to the player.
            anim.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            doubleJump = true;
        }

        if(stamina > 0)
        {
            if (!grounded && jump && doubleJump && stamina >= 20)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("Jump", true);
                doubleJump = false;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                rigidbody2D.AddForce(new Vector2(0, jumpForce));
                stamina -= 20;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Sprint();
            }

            if (Input.anyKey != Input.GetKey(KeyCode.LeftShift))
            {
                maxSpeed = 18f;
                playerIsSprinting = false;
            }
        }
       
        if(touchingWall && jump && !wallJumped)
        {
            anim.SetBool("Wall", false);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
            rigidbody2D.AddForce(new Vector2(10f, jumpForce));
            doubleJump = true;
            wallJumped = true;
            animation.Play(wall.name);
        }

        if (!touchingWall || grounded)
        {
            wallJumped = false;
        }

        if(stamina <= 0)
        {
            maxSpeed = 18f;
        }

        
	} 

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    public void Sprint()
    {
        maxSpeed = sprintSpeed;
        staminaSprintTimer += Time.deltaTime;
        Debug.Log("Before check");
        if(staminaSprintTimer >= 0.10)
        {
            Debug.Log("in if");
            staminaSprintTimer = 0;
            stamina -= 2;
            playerIsSprinting = true;
            Debug.Log(playerIsSprinting);
        }
        
    }

    public bool playerIsSprinting = false;

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(staminaBarPos.x, staminaBarPos.y, staminaBarSize.x, stamina* 3));
        GUI.Box(new Rect(0, 0, staminaBarSize.x, stamina* 3), "", customStyle);
        GUI.EndGroup();
    }
}