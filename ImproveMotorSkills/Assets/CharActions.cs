using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharActions : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    Timer timer;

    public MoveObsticles cube;

    // Values
    float jump_force_muil = 28;
    float rotate_speed = 500;

    int rotate_points = 0;


    // Bools
    public bool grounded = false;
    public bool jumping = false;
    public bool sliding = false;
    public bool dogeding = false;

    public bool cantDodge = false;


    // Private
    private bool interactable = false;
    private bool doged = false;
    private bool jumped = false;
    private bool slided = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        timer = GetComponent<Timer>();

        timer.StartTimer();

        interactable = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(interactable)
        {
            // Timer still going
            if (!timer.TimerReachedEnd())
            {
                timer.UpdateTimer();

                // If a correct key has been pressed
                if (Input.GetKeyDown(KeyCode.A))
                {
                    // Store time

                    // reset timer
                    timer.ResetTimer();
                    timer.UpdateTimer();

                    // Dodging state true
                    interactable = false;

                    doged = true;

                    cube.ActivateObject();
                }

                if (!doged && timer.GetCurrentTime() > 2f)
                {
                    cube.ActivateObject();
                }
            }

            // Not Dodged  in time
            if(cantDodge)
            {
                rb.bodyType = RigidbodyType2D.Static;

                transform.Rotate(Vector3.forward * rotate_speed * Time.deltaTime);

                // Roate until the last poine
                if (transform.eulerAngles.z >= 355)
                {
                    rotate_points++;

                    //Debug.Log("rotated num cout: " + rotate_points);

                    transform.rotation = new Quaternion(0, 0, 0, 0);
                }

                if (rotate_points == 2)
                {
                    rotate_points = 0;

                    cantDodge = false;

                    rb.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }

        // Dodged
        if (doged)
        {
            if(!dogeding)
            {
                if (cube.gameObject.transform.position.x <= (this.transform.position.x + 5) &&
                    cube.gameObject.transform.position.x >= (this.transform.position.x))
                {
                    jumping = true;
                    jumped = true;

                    dogeding = true;
                    doged = false;
                }
            }
        }

        if(cube.GetObjectActive())
        {
            cube.UpdateObject();
        }
    }

    // Fixed update
    private void FixedUpdate()
    {
        if (jumped)
        {
            rb.AddForce(Vector2.up * jump_force_muil, ForceMode2D.Impulse);

            jumped = false;
        }
    }

    // collistion - Enter
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Grounded
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;

            if(dogeding)
            {
                dogeding = false;

                timer.StartTimer();
                interactable = true;
            }
        }
    }

    // collistion - Exit
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Grounded
        if (doged && collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    // Trigerbale - Enter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!doged)
        {
            // Not Dodged
            if (!cantDodge && collision.gameObject.tag == "Dodgeable")
            {
                cantDodge = true;

                //Debug.Log("Not doged: " + rotate_points);
            }
        }
    }
}
