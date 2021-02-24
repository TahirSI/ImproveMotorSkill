using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUpdate : MonoBehaviour
{
    // Private
    private bool performence = false;
    private bool interactable = true;
    private bool acations = false;
    private bool inputed = false;

    private bool doged = false;


    private int inputIndex = 0;

    // External
    private Settings settings;

    private Timer waitToStartTimer;
    private Timer inputTimer;

    private InputSelection inputSelctions;
    public DisplayedInput displayedInput;

    // Public
    public PlayerAcations playerAcations;

    // Objects to doage
    public MoveDodgable objectToDodge;

    // Start is called before the first frame update
    void Start()
    {
        settings = GetComponent<Settings>();

        waitToStartTimer = gameObject.AddComponent<Timer>();
        inputTimer = gameObject.AddComponent<Timer>();

        inputSelctions = GetComponent<InputSelection>();


        // Get the randome keys
        for (int i = 0; i < settings.kyes.Length; i++)
        {
            // Get the rand value
            settings.inputValues[i] = inputSelctions.GetRandNumber(0, 25);

            // Set the rand key based on the value
            settings.kyes[i] = inputSelctions.GetRandInout(settings.inputValues[i]);
        }

        // Set the displyed input
        displayedInput.SetImage(settings.inputValues[0]);

        displayedInput.SetPosShift(new Vector3(67 / 2, 90, 0));


        inputTimer.StartTimer();

        // Set wait time - 1 sec
        waitToStartTimer.timerToStopAt = 1;

        // Set input timer
        inputTimer.timerToStopAt = settings.dodgeTime;


        // Set the dodgale object speed

        // Ech grid square is 50px  
        settings.dodgableObjectsSpeed = 50 *
            (settings.dodgableObjectPernet.transform.position.x - 1 * 2) /
            (60 * settings.dodgeTime);

        // Ground speed to mach
        settings.groundSpeed = settings.dodgableObjectsSpeed;

        // Set the dogable obejct speed
        objectToDodge.speed = settings.dodgableObjectsSpeed;

    }

    [System.Obsolete]
    void Update()
    {
        // Speed up update
        if (!performence)
        {
            // Waiting to start the next interaction
            if (!interactable)
            {
                waitToStartTimer.UpdateTimer();

                // Timer ended
                if (!waitToStartTimer.GetTimerStillOn())
                {
                    waitToStartTimer.ResetTimer();
                    inputTimer.StartTimer();

                    interactable = true;

                    objectToDodge.ActivateObject();
                }
            }
            else
            {
                if (inputTimer.GetTimerStillOn())
                {
                    inputTimer.UpdateTimer();

                    // If inputed 
                    if (Input.GetKeyDown(settings.kyes[inputIndex]))
                    {
                        // Get the input time

                        inputTimer.ResetTimer();

                        // Decativate displayyed input
                        displayedInput.DeactivateObject();

                        inputed = true;

                        // Increase input index
                        inputIndex++;

                        if(inputIndex > settings.kyes.Length)
                        {
                            inputIndex = 0;
                        }
                    }

                    if (!inputed)
                    {
                        // Input timer reached end
                        if (inputTimer.TimerReachedEnd())
                        {
                            inputTimer.ResetTimer();

                            performence = true;
                        }
                    }
                }
            }
        }

        // Displyed input
        if (displayedInput.GetAcativeObject())
        {
            displayedInput.Move(objectToDodge.GetObjectPos());
        }

        // Dodgable object
        if (objectToDodge.GetObjectActive())
        {
            // Update the dodge object
            objectToDodge.UpdateObject();

            // If inputed
            if (inputed)
            {
                if (objectToDodge.GetObjectPos().x < 10)
                {
                    // Inputed back to false
                    inputed = false;

                    acations = true;
                    doged = true;
                }
            }
        }

        // Actions need to happen
        if (acations)
        {
            // Doged the object
            if (doged)
            {
                // Set the playerAcation
            }

            // Hit the object
            else
            {

            }
        }
    }
}