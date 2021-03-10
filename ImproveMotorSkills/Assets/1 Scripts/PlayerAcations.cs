using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAcations : MonoBehaviour
{
    private Vector3 orignalPos = Vector3.zero;
    private Quaternion orignalRot = Quaternion.identity;

    private float jumpForceMuil = 20;

    private bool stillJump = false;
    private bool jumped = false;

    // Geting Hit
    private bool getingHit = false;

    private bool getStillHit = false;
    private bool getHitRoataing = false;

    private bool grounded = false;

    // Got hit - roatation
    private float rotateSpeed = 0;
    private int amountRoatations = 0;

    private Rigidbody2D rb;

    public Settings settings;

    // Start
    private void Start()
    {
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
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);


            if (transform.eulerAngles.z >= 350)
            {
                // Chnage roation is handled
                // Keep add to current rot mount - 356 + next amount

                // Increats amaout roation
                amountRoatations++;

                if(amountRoatations > 2)
                {
                    rb.bodyType = RigidbodyType2D.Dynamic;

                    // Set roatation
                    transform.rotation = orignalRot;

                    amountRoatations = 0;

                    getStillHit = false;

                    getHitRoataing = false;
                }
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
            if (!grounded && collision.gameObject.tag == "Ground")
            {
                grounded = true;

                stillJump = false;
            }
        }

    // collistion - Exit
    private void OnCollisionExit2D(Collision2D collision)
    {
     ;   // Not Grounded
        if (grounded && stillJump && collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }


    // Activations

    // Goy hit
    public void ActivateGotHit()
    {
        getingHit = true;

        rb.bodyType = RigidbodyType2D.Static;
    }

    // Jumping
    public void ActivateJump()
    {
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
}
