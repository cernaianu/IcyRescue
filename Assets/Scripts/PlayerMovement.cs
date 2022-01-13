using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick movementJoystick;
    public float movementSpeed = 10.0f;
    public float jumpSpeed = 5.0f;
    public float fallMultiplier = 3.0f;
    //public float fallingSpeedIncrement = 0.25f;
    private PlayerController playerController;
    private bool isOnLand;
    private bool isOnSlipperyTerrain;
    private bool shouldJump = false;
    private float gravity = 1.0f;


    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        

    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        isOnLand = playerController.CirclePlayerCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        isOnSlipperyTerrain = playerController.isOnSlipperySurface();
        
        //Debug.Log(isOnLand);

        if (movementJoystick.Horizontal >= 0.01f)
        {
            if (isOnSlipperyTerrain)
                playerController.Rb.AddForce(new Vector2(movementSpeed, playerController.Rb.velocity.y), ForceMode2D.Force);
            else
            playerController.Rb.velocity = new Vector2(movementSpeed , playerController.Rb.velocity.y);
            playerController.SpriteRenderer.flipX = false;
        }
        else if (movementJoystick.Horizontal <= 0.01f && movementJoystick.Horizontal != 0)
        {
            if (isOnSlipperyTerrain)
                playerController.Rb.AddForce(new Vector2(-movementSpeed, playerController.Rb.velocity.y), ForceMode2D.Force);
            playerController.Rb.velocity = new Vector2(-movementSpeed  , playerController.Rb.velocity.y);
            playerController.SpriteRenderer.flipX = true;
        }
        
        else
        {
            playerController.Rb.velocity = new Vector2(0, playerController.Rb.velocity.y);
        }

        if (shouldJump)
        {
            //Translate it upwards with time.
            Jump();
            
            //Make sure the Rigidbody is kinematic, or gravity will pull us down again
            
        }
        // if(movementJoystick.Vertical >= 0.2f)
        //  Jump();
        multiplyFall();


        // Debug.Log(movementJoystick.Vertical);
        
        playerController.PlayerAnimator.SetFloat("movementSpeed", Mathf.Abs(playerController.Rb.velocity.x));
        playerController.PlayerAnimator.SetBool("isOnLand", isOnLand);

    }

    public void Jump()
    {
        
        if (!isOnLand)
        {
            //playerController.Rb.velocity -= new Vector2(0, fallingSpeedIncrement);
            return;
        }

        else
        {
            playerController.Rb.velocity = new Vector2(playerController.Rb.velocity.x, 0);
            playerController.Rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);

        }

        //playerController.Rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        //playerController.Rb.velocity = SmoothDamp.//new Vector2(playerController.Rb.velocity.x, jumpSpeed);

        //playerController.Rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        
        
    }

    private void multiplyFall()
    {
        if (isOnLand)
        {
            playerController.Rb.gravityScale = 0;
            fallMultiplier = 2.0f;
        }
        else
        {
            
            playerController.Rb.gravityScale = gravity;
            if (playerController.Rb.velocity.y < 0)
            {
                playerController.Rb.gravityScale = gravity * fallMultiplier;
            }
        }
    }


    //When the button is being pressed down, this function is called.
    public void ButtonPressedDown(BaseEventData e)
    {
        shouldJump = true;
    }

    //When the button is released again, this function is called.
    public void ButtonPressedUp(BaseEventData e)
    {
        shouldJump = false;
    }
}
