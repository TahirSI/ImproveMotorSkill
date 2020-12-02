using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharActions : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    // Values
    float jump_force_muil = 28;
    float rotate_speed = 300;

    int rotate_points = 0;


    // Bools
    public bool grounded = false;
    public bool juping = false;

    public bool notDodged = false;


    private bool jumped = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded && !jumped)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                jumped = true;

                juping = true;
            }
        }

        // Not Dodged
        if(notDodged)
        {
            rb.bodyType = RigidbodyType2D.Static;

            transform.Rotate(Vector3.back * rotate_speed * Time.deltaTime);

            //Debug.Log("z angle: " + transform.eulerAngles.z);

            float deg = 90f;

            float rad = deg * Mathf.Deg2Rad;

            if (transform.eulerAngles.z >= -rad)
            {
                rotate_points++;

                Debug.Log("rotated num: " + rotate_points);
            }

            if(rotate_points == 2)
            {
                rotate_points = 0;

                notDodged = false;

                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }

        // Dodged
        else
        {

        }
    }

    private void FixedUpdate()
    {

        if (jumped)
        {
            rb.AddForce(Vector2.up * jump_force_muil, ForceMode2D.Impulse);

            jumped = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Grounded
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            juping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Grounded
        if (juping && collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Dodging
        if (collision.gameObject.tag == "Dodgeable")
        {
            notDodged = true;
        }
    }
}
