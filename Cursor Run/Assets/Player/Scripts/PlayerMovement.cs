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
    public float maxMaxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0f;

    public float jumpGroundThreshold = 1;

    public Transform front;
    public Transform back;



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
        
        if(!isGrounded) 
        {
            //JumpHold
            if(isHoldingJump)
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


            //Check for ground
            Vector2 RayOrigin = front.transform.position;
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(RayOrigin, rayDirection, rayDistance);
            if(hit2D.collider != null)
            {
                Ground ground = hit2D.collider.GetComponent<Ground>();
                if(ground != null)
                {
                    groundHeight = ground.groundHeight;
                    pos.y = groundHeight;
                    isGrounded = true;
                }
            }

            Debug.DrawRay(RayOrigin, rayDirection * rayDistance, Color.red);

            
        }

        distance += velocity.x * Time.fixedDeltaTime;

        if (isGrounded)
        {
            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio); //acceleration will lower as speed increases
            maxHoldJumpTime = maxMaxHoldJumpTime * velocityRatio;
            

            velocity.x += acceleration * Time.fixedDeltaTime;
            if (velocity.x >= maxXVelocity) velocity.x = maxXVelocity;

            //Check for not ground
            Vector2 RayOrigin = back.transform.position;
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(RayOrigin, rayDirection, rayDistance);
            if (hit2D.collider == null)
            { 
                isGrounded = false;
            }

            Debug.DrawRay(RayOrigin, rayDirection * rayDistance, Color.yellow);
        }

        transform.position = pos;
    }
}
