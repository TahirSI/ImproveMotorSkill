using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharActions : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public Camera cam;

    public Timer timerIneract;
    public Timer timerWatingToStart;

    public MoveDodgable dogableObject;

    // Values
    private float jumpForceMuil = 20;
    private float rotateSpeed = 500;

    private int rotatePoints = 0;

    private Vector3 playerStartPos = Vector3.zero;
    private Vector3 cameraStartPos = Vector3.zero;

    public int[] setRand = { 0, 0, 0 };
    public string[] randInputs = { " ", " ", " " };
    public int inputIndexSeter = 0;

    public Text [] inputsText;


    // Bools
    public bool grounded = false;
    public bool jumping = false;
    public bool sliding = false;
    public bool doginng = false;

    public bool cantDodge = false;


    // Private
    private bool waitingToInteract = false;

    private bool interactable = false;
    private bool doged = false;

    private bool cameraShift = false;
    private bool cameraNeadsToBack = false;

    // Acations
    private bool secondary = false;

    private bool jumped = false;

    private bool slided = false;
    private bool slideingReached = false;

    
    // Start is called before the first frame update
    void Start()
    {
        RandmiseInputs();

        inputsText[0].text = randInputs[0];
        inputsText[1].text = randInputs[1];
        inputsText[2].text = randInputs[2];

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // The starting pint for player
        playerStartPos = this.transform.position;
        cameraStartPos = FindObjectOfType<Camera>().transform.position;

        // Temp start
        timerIneract.StartTimer();

        interactable = true;

    }

    // Update is called once per frame
    void Update()
    {
        // Waiting to start the next interaction
        if (waitingToInteract)
        {
            timerWatingToStart.UpdateTimer();

            // Timer ended
            if (timerWatingToStart.TimerReachedEnd())
            {
                timerWatingToStart.ResetTimer();
                waitingToInteract = false;

                timerWatingToStart.UpdateTimer();

                timerIneract.StartTimer();
                interactable = true;
            }
        }

        // Can interact
        if (interactable)
        {
            // Timer still going
            if (!timerIneract.TimerReachedEnd())
            {
                timerIneract.UpdateTimer();

                // If a correct key has been pressed
                if (Input.GetKeyDown(GetRandInout(setRand[inputIndexSeter])))
                {
                    // Store time



                    if (timerIneract.GetCurrentTime() > 2)
                    {
                        // Secondary dodged
                        secondary = true;

                        cameraNeadsToBack = true;
                    }

                    // Input repetion checker
                    inputIndexSeter++;

                    // If it's reached the last one
                    if (inputIndexSeter > setRand.Length - 1)
                    {
                        inputIndexSeter = 0;
                    }

                    // reset timer
                    timerIneract.ResetTimer();
                    timerIneract.UpdateTimer();

                    // Dodging state false
                    interactable = false;

                    doged = true;

                    dogableObject.ActivateObject();
                }

                if (!dogableObject.GetObjectActive() && timerIneract.GetCurrentTime() > 2f)
                {
                    dogableObject.ActivateObject();

                    // Camera shift
                    cameraShift = true;
                }
            }

            // Didn't Dodged in time
            if (cantDodge)
            {
                rb.bodyType = RigidbodyType2D.Static;

                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

                // Roate until the last poine
                if (transform.eulerAngles.z >= 355)
                {
                    rotatePoints++;

                    //Debug.Log("rotated num cout: " + rotate_points);

                    transform.rotation = new Quaternion(0, 0, 0, 0);
                }

                // Reached rot limit
                if (rotatePoints == 2)
                {
                    rotatePoints = 0;

                    cantDodge = false;

                    rb.bodyType = RigidbodyType2D.Dynamic;

                    // Input repetion checker
                    inputIndexSeter++;

                    // If it's reached the last one
                    if (inputIndexSeter > setRand.Length - 1)
                    {
                        inputIndexSeter = 0;
                    }

                    // reset timer
                    timerIneract.ResetTimer();
                    timerIneract.UpdateTimer();

                    interactable = false;

                    // Wait time start
                    waitingToInteract = true;
                    timerWatingToStart.StartTimer();
               }
            }
        }

        // Camera change
        if (cameraShift)
        {
            CameraMovinng();
        }

        // Dodged
        if (doged)
        {
            if (!doginng)
            {
                if (dogableObject.gameObject.transform.position.x <= (this.transform.position.x + 5) &&
                    dogableObject.gameObject.transform.position.x >= (this.transform.position.x))
                {
                    // Primary
                    if (!secondary)
                    {
                        jumping = true;
                        jumped = true;
                    }

                    // Secondary
                    else
                    {
                        rb.bodyType = RigidbodyType2D.Static;

                        sliding = true;
                        slided = false;

                        secondary = false;
                    }

                    doginng = true;
                    doged = false;
                }
            }
        }

        // Sliding
        if (sliding)
        {
            SlidingAction();
        }

        if (dogableObject.GetObjectActive())
        {
            dogableObject.UpdateObject();
        }
    }

    // Get inputs
    void RandmiseInputs()
    {
        string[] letterInputs = {
            "a","b","c","d","e","f","g","h","i","j","k","l","m",
            "n","o","p","q","r","s","t","u","v","w","x","y","z"
        };

        int i = 0;

        do
        {
            setRand[i] = Random.Range(0, 26);

            if (setRand[i] > 0)
            {
                for (int j = 0; j < i; j++)
                {
                    do
                    {
                        setRand[i] = Random.Range(0, 26);

                    } while (setRand[j] == setRand[i]);
                }
            }

            randInputs[i] = letterInputs[setRand[i]];


            i++;

        } while (i < randInputs.Length);
    }

    private KeyCode GetRandInout(int index)
    {
        KeyCode retunKeyCod = KeyCode.A;

        if (index == 0)       // A
        {
            retunKeyCod = KeyCode.A;
        }
        else if (index == 1)  // B
        {
            retunKeyCod = KeyCode.B;
        }
        else if (index == 2)  // C
        {
            retunKeyCod = KeyCode.C;
        }
        else if (index == 3)  // D
        {
            retunKeyCod = KeyCode.D;
        }
        else if (index == 4)  // E
        {
            retunKeyCod = KeyCode.E;
        }
        else if (index == 5) // F
        {
            retunKeyCod = KeyCode.F;
        }
        else if (index == 6)  // G
        {
            retunKeyCod = KeyCode.G;
        }
        else if (index == 7)  // H
        {
            retunKeyCod = KeyCode.H;
        }
        else if (index == 8)  // I
        {
            retunKeyCod = KeyCode.I;
        }
        else if (index == 9)  // J
        {
            retunKeyCod = KeyCode.J;
        }
        else if (index == 10) // K
        {
            retunKeyCod = KeyCode.K;
        }
        else if (index == 11) // L
        {
            retunKeyCod = KeyCode.L;
        }
        else if (index == 12) // M
        {
            retunKeyCod = KeyCode.M;
        }
        else if (index == 13) // N
        {
            retunKeyCod = KeyCode.N;
        }
        else if (index == 14) // O
        {
            retunKeyCod = KeyCode.O;
        }
        else if (index == 15) // P
        {
            retunKeyCod = KeyCode.P;
        }
        else if (index == 16) // Q
        {
            retunKeyCod = KeyCode.Q;
        }
        else if (index == 17) // R
        {
            retunKeyCod = KeyCode.R;
        }
        else if (index == 18) // S
        {
            retunKeyCod = KeyCode.S;
        }
        else if (index == 19) // T
        {
            retunKeyCod = KeyCode.T;
        }
        else if (index == 20) // U
        {
            retunKeyCod = KeyCode.U;
        }
        else if (index == 21) // V
        {
            retunKeyCod = KeyCode.V;
        }
        else if (index == 22) // W
        {
            retunKeyCod = KeyCode.W;
        }
        else if (index == 23) // X
        {
            retunKeyCod = KeyCode.X;
        }
        else if (index == 24) // Y
        {
            retunKeyCod = KeyCode.Y;
        }
        else if (index == 25) // Z
        {
            retunKeyCod = KeyCode.Z;
        }

        return retunKeyCod;
    }


    // Camera
    void CameraMovinng()
    {
        if (!cameraNeadsToBack)
        {
            Vector3 move = new Vector3(1.5f, 0, 3);

            cam.transform.position += move * Time.deltaTime;

            if (dogableObject.transform.position.x <= this.transform.position.x)
            {
                cameraNeadsToBack = true;
            }
        }

        if (cameraNeadsToBack)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, cameraStartPos, Time.deltaTime * 10);

            if (cam.transform.position.x <= cameraStartPos.x + 0.5f)
            {
                cam.transform.position = cameraStartPos;

                cameraNeadsToBack = false;
                cameraShift = false;
            }
        }
    }

    // Diffrent actions

    // liding
    void SlidingAction()
    {
        if (!slideingReached)
        {
            Vector3 move = new Vector3(7, 0, 0);

            this.transform.position += move * Time.deltaTime;

            // Reached the end point
            if (this.transform.position.x >= (playerStartPos.x + 6))
            {
                slideingReached = true;
            }
        }
        else
        {

            Vector3 move = new Vector3(6, 0, 0);

            this.transform.position -= move * Time.deltaTime;

            // Reached the starting pos
            if (this.transform.position.x <= playerStartPos.x)
            {
                this.transform.position = playerStartPos;

                doginng = false;

                sliding = false;
                slideingReached = false;

                rb.bodyType = RigidbodyType2D.Dynamic;

                // Wait time strat
                timerWatingToStart.StartTimer();
                waitingToInteract = true;
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
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;

            if(doginng)
            {
                // Jumpin
                if(jumping)
                {
                    doginng = false;

                    jumping = false;

                    // Wait time start
                    timerWatingToStart.StartTimer();
                    waitingToInteract = true;
                }
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
        if(!doginng)
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
