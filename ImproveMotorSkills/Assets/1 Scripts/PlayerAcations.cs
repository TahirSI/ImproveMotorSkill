using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAcations : MonoBehaviour
{
    private Vector3 orignalPos = Vector3.zero;
    private Quaternion orignalRot = Quaternion.identity;

    private float jumpForceMuil = 20;

    private bool stillJump;
    private bool jumped;

    
    // Geting Hit
    private bool getingHit;

    private bool getStillHit;
    private bool getHitRoataing;

    private bool grounded;

    // Got hit - roatation
    private float rotateSpeed;
    private float amountRoatations;

    private Rigidbody2D rb;

    public Settings settings;

    // Start
    private void Start()
    {
        //Start
        orignalPos = transform.position;
        
        rb = GetComponent<Rigidbody2D>();
        
        orignalPos = transform.position;
        orignalRot = transform.rotation;

        jumpForceMuil = settings.playerJumpMulti;

        rotateSpeed = settings.gotHitrotSpeed;
    }

    // Got hit
    public void UpdateGotHit()
    {
        if(getingHit)
        {
            if(transform.position.x <= 3)
            {
                getingHit = false;

                getStillHit = true;

                getHitRoataing = true;
            }
        }


        // Roataing
        if (getHitRoataing)
        {
            // Roataion
            transform.Rotate(Vector3.forward * (rotateSpeed * Time.deltaTime));

            // Amount
            amountRoatations += rotateSpeed * Time.deltaTime;

            if (amountRoatations >= 360 * 2)
            {
                // Set roatation
                transform.rotation = orignalRot;

                amountRoatations = 0;

                getStillHit = false;

                getHitRoataing = false;
            }
        }
    }

    // Fixed update
    private void FixedUpdate()
    {
        if (jumped)
        {
            rb.AddForce(Vector2.up * jumpForceMuil, ForceMode2D.Impulse);

            jumped = false;
        }

    }


    // collistion - Enter
    private void OnCollisionEnter2D(Collision2D collision)
        {
            // Grounded
            if (!grounded && collision.gameObject.CompareTag("Ground"))
            {
                grounded = true;

                stillJump = false;
                
                rb.bodyType = RigidbodyType2D.Static;

                transform.position = orignalPos;
            }
        }

    // collistion - Exit
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Not Grounded
        if (grounded && stillJump && collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }


    // Activations

    // Goy hit
    public void ActivateGotHit()
    {
        getingHit = true;
    }

    // Jumping
    public void ActivateJump()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;

        stillJump = true;

        jumped = true;
    }


    // Getteres

    public bool GetIfStillJumping()
    {
        return stillJump;
    }

    // Getting hit
    public bool GetStillHiting()
    {
        return getStillHit;
    }

    // Ground check
    public bool GetGrounded()
    {
        return grounded;
    }

    public Rigidbody2D GETHitRoataing()
    {
        return rb;
    }
}
