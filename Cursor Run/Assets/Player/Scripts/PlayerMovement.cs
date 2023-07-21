using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public float maxAcceleration = 10;
    public float acceleration = 10;
    public float distance = 0;
    public float jumpVelocity = 20;
    public float maxXVelocity = 100;
    public float groundHeight = 0;
    public bool isGrounded = false;

    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float holdJumpTimer;

    public float jumpGroundThreshold = 1;


    void Update()
    {
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);
        if (isGrounded || groundDistance <= jumpGroundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                holdJumpTimer = 0;
            }
        }            
        if (Input.GetKeyUp(KeyCode.Space))
            {
                isHoldingJump = false; 
            }
    }


    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        if (!isGrounded) 
        {
            //JumpHold
            if (isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;
                if (holdJumpTimer >= maxHoldJumpTime) 
                {
                    isHoldingJump = false; //forces player to stop jumping after a certain time
                }
            }

            pos.y += velocity.y * Time.fixedDeltaTime;
            
            //Gravity
            if (!isHoldingJump) 
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }
            
            Vector2 RayOrigin = new Vector2(pos.x + 4f, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(RayOrigin, rayDirection, rayDistance);
            if(hit2D.collider != null)
            {

            }
            
            //IsGrounded check
            //if(pos.y <= groundHeight) 
            //{
            //    pos.y = groundHeight;
            //    isGrounded = true;
            //}
        }

        distance += velocity.x * Time.fixedDeltaTime;

        if (isGrounded)
        {
            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio); //acceleration will lower as speed increases
            
            velocity.x += acceleration * Time.fixedDeltaTime;
            if (velocity.x >= maxXVelocity) velocity.x = maxXVelocity;
        }

        transform.position = pos;
    }
}
