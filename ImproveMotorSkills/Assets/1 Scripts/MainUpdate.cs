using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUpdate : MonoBehaviour
{
    // Private
    private bool fishedCollcting = false;

    //private bool practice = false;
    //private bool showIntroCards = false;

    private bool readyingAnouncment = false;
    private bool playGame = false;
    private bool paused = false;

    private bool performence = false;
    private bool interactable = false;
    private bool acations = false;
    private bool inputed = false;

    private bool doged = false;

    private int inputIndex = 0;
    private float[] timesStored = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


    // External
    private Settings settings;

    // Game data
    public GameDataControl gameDataControl;
    public GameDataSaveLoad gameDataSaveLoad;

    // Timeres
    private Timer gettingReadyTimer;
    private Timer waitToStartTimer;
    private Timer inputTimer;

    private UIControler uIControler;

    // Dislsyed input
    private InputSelection inputSelctions;
    public DisplayedInput displayedInput;

    // Public
    public PlayerAcations playerAcations;

    // Objects to doage
    public MoveDodgable objectToDodge;

    public MovingText moveReadyText;
    public MovingText moveGoText;

    // Start is called before the first frame update
    private void Start()
    {
        settings = GetComponent<Settings>();

        gettingReadyTimer = gameObject.AddComponent<Timer>();
        waitToStartTimer = gameObject.AddComponent<Timer>();
        inputTimer = gameObject.AddComponent<Timer>();

        inputSelctions = GetComponent<InputSelection>();

        uIControler = FindObjectOfType<UIControler>();

        // Get the randome keys
        for (int i = 0; i < settings.kyes.Length; i++)
        {
            // Get the rand value
            settings.inputValues[i] = inputSelctions.GetRandNumber(0, 25);

            // Set the rand key based on the value
            settings.kyes[i] = inputSelctions.GetRandInout(settings.inputValues[i]);
        }

        // Set the displyed input
        displayedInput.SetImage(settings.inputValues[inputIndex]);

        // Set pos des
        displayedInput.SetPosShift(new Vector3(67 / 2, 90, 0));

        // Display ready 
        gettingReadyTimer.timerToStopAt = 0.8f;


        // Set wait time - 1 sec
        waitToStartTimer.timerToStopAt = 1;

        // Set input timer
        inputTimer.timerToStopAt = settings.dodgeTime;


        // Set the dodgale object speed

        // Ech grid square is 50px  
        settings.dodgableObjectsSpeed = 50 *
            ((settings.dodgableObjectPernet.transform.position.x - 3) * 2) /
            (100 * settings.dodgeTime);

        // Ground speed to mach
        settings.groundMoveSpeed = settings.dodgableObjectsSpeed;

        // Set the dogable obejct speed
        objectToDodge.speed = settings.dodgableObjectsSpeed;

        //practice = gameDataControl.GetNeedToPractice();

        playGame = true;

        readyingAnouncment = true;


        // Set scale to anaime at
        moveReadyText.SetMinMaxScales(settings.readytextScalMinMax.x, settings.readytextScalMinMax.y);

        // Set Go text
        moveGoText.SetMinMaxScales(settings.gotextScalMinMax.x, settings.gotextScalMinMax.y);

        // Start getting ready timer
        gettingReadyTimer.StartTimer();
    }

    void Update()
    {
        // playing game
        if (playGame)
        {
            // Not paused
            if (!paused)
            {

                if (readyingAnouncment)
                {
                    if(gettingReadyTimer.GetTimerStillOn())
                    {
                        // Update timer
                        gettingReadyTimer.UpdateTimer();

                        if(!gettingReadyTimer.GetTimerStillOn())
                        {
                            // Anouncements - Active
                            uIControler.ActivateAnoucments();

                            // Ready text
                            uIControler.ActivateReadyText();

                            // Set ready speed
                            moveReadyText.SetScaleSpeed(settings.readyTextScaleSpeed.x);

                            // Set Ready fade speed
                            moveReadyText.SetFadeSpedd(settings.readyTextFadeSpeed.x);
                        }
                    }
                    else
                    {
                        // Ready text is ON 
                        if (uIControler.GetReadyText())
                        {
                            // Last scale
                            if(moveReadyText.GetCurrentScale().x >=
                                moveReadyText.GetMidScaleDis())
                            {
                                // Set ready speed
                                moveReadyText.SetScaleSpeed(settings.readyTextScaleSpeed.z);

                                // Set Ready fade speed
                                moveReadyText.SetFadeSpedd(settings.readyTextFadeSpeed.y);
                            }

                            // Mid scale
                            else if (moveReadyText.GetCurrentScale().x >=
                                moveReadyText.GetStartScaleDis())
                            {
                                // Set ready scale speed
                                moveReadyText.SetScaleSpeed(settings.readyTextScaleSpeed.y);
                            }


                            // Update ready text
                            moveReadyText.UpdateText();


                            // Go text
                            if (!uIControler.GetGoText() &&
                                moveReadyText.GetCurrentScale().x >=
                                moveReadyText.GetMidScaleDis())
                            {

                                uIControler.ActivateGoText();

                                // Set Go scale speed
                                moveGoText.SetScaleSpeed(settings.goTextScaleSpeed.x);

                                // Set Go fade speed
                                moveGoText.SetFadeSpedd(settings.goTextFadeSpeed.x);
                            }

                        }

                        // If Go text is ON
                        if (uIControler.GetGoText())
                        {
                            // Last scake
                            if (moveGoText.GetCurrentScale().x <=
                                moveGoText.GetMidScaleDis())
                            {
                                // Set ready speed
                                moveGoText.SetScaleSpeed(settings.goTextScaleSpeed.z);

                                // Set Go fade speed
                                moveGoText.SetFadeSpedd(settings.goTextFadeSpeed.y);
                            }

                            // Mid scale
                            else if (moveGoText.GetCurrentScale().x <=
                                moveGoText.GetStartScaleDis())
                            {
                                // Set ready speed
                                moveGoText.SetScaleSpeed(settings.goTextScaleSpeed.y);
                            }


                            // Update go text
                            moveGoText.UpdateText();
                        }

                        // Timer readyingAnouncment
                        if (!uIControler.GetReadyText() &&
                            !uIControler.GetGoText())
                        {
                            gettingReadyTimer.ResetTimer();

                            uIControler.DeActivateAnoucments();

                            readyingAnouncment = false;


                            // Start the game wait time
                            waitToStartTimer.StartTimer();
                        }
                    }
                }
                

                // Reading has stoped
                else
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

                                // Set the disply input
                                displayedInput.SetImage(settings.inputValues[inputIndex]);

                                displayedInput.ActivateObject();
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
                                    // Store data — the input time
                                    timesStored[inputIndex] = inputTimer.GetCurrentTime();
                                    // Temp storage

                                    // UI set score
                                    uIControler.SetJustGotScoreText(inputIndex, timesStored[inputIndex]);


                                    inputTimer.ResetTimer();

                                    // Decativate displayyed input
                                    displayedInput.DeactivateObject();

                                    // Set the speed ups
                                    objectToDodge.speed = settings.objectsFastSpeed;
                                    settings.groundMoveSpeed = settings.objectsFastSpeed;

                                    inputed = true;

                                    // Increase input index
                                    inputIndex++;

                                    interactable = false;

                                    performence = true;
                                }

                                // Not inputed
                                if (!inputed)
                                {
                                    // Input timer reached end
                                    if (inputTimer.TimerReachedEnd())
                                    {
                                        inputTimer.ResetTimer();

                                        // Set the UI score
                                        uIControler.SetJustGotScoreText(inputIndex, timesStored[inputIndex]);

                                        // Increase input index
                                        inputIndex++;

                                        // Decativate displayyed input
                                        displayedInput.DeactivateObject();

                                        // Geting hit
                                        playerAcations.ActivateGotHit();

                                        acations = true;

                                        interactable = false;

                                        performence = true;
                                    }
                                }

                                // If input reached last one 
                                if (inputIndex > settings.kyes.Length - 1)
                                {
                                    fishedCollcting = true;

                                    inputIndex = 0;

                                    // if not stored permant
                                    if (!gameDataControl.GetPermanentDataStored())
                                    {
                                        for (int i = 0; i < timesStored.Length; i++)
                                        {
                                            // storeing the permant data
                                            gameDataControl.StorePermanentReults(i, timesStored[i]);

                                            uIControler.SetSentScoreData(i, timesStored[inputIndex]);
                                        }

                                        // Permant storage stored
                                        gameDataControl.SetPermanentDataStorage(true);
                                    }

                                    // Store chnagable storage
                                    else
                                    {
                                        for (int i = 0; i < timesStored.Length; i++)
                                        {
                                            // storeing the Changimng data
                                            gameDataControl.StoreChangeableReults(i, timesStored[i]);
                                        }
                                    }

                                    // Save data
                                    gameDataSaveLoad.SaveData();
                                }
                            }
                        }
                    }

                    // Dodgable object
                    if (objectToDodge.GetObjectActive())
                    {
                        // Update the dodge object
                        objectToDodge.UpdateObject();

                        // If inputed
                        if (inputed)
                        {
                            if (objectToDodge.GetObjectPos().x < 4)
                            {
                                // Inputed back to false
                                inputed = false;

                                acations = true;
                                doged = true;

                                // Set the speed back to normal
                                objectToDodge.speed = settings.dodgableObjectsSpeed;
                                settings.groundMoveSpeed = settings.dodgableObjectsSpeed;

                                playerAcations.ActivateJump();
                            }
                        }
                    }

                    // Displyed input
                    if (displayedInput.GetAcativeObject())
                    {
                        displayedInput.Move(objectToDodge.GetObjectPos());
                    }

                    // Actions need to happen
                    if (acations)
                    {
                        bool check = false;

                        // Doged the object
                        if (doged)
                        {
                            if (!playerAcations.GetIfStillJumping())
                            {
                                doged = false;

                                check = true;
                            }
                        }
                        // Hit the object
                        else
                        {
                            playerAcations.UpdateGotHit();

                            if (!playerAcations.GetStillHiting())
                            {
                                check = true;
                            }
                        }

                        // Fished acation
                        if (check)
                        {
                            acations = false;

                            performence = false;

                            // Not coled all results
                            if (!fishedCollcting)
                            {
                                waitToStartTimer.StartTimer();
                            }

                            // Fished collection
                            else
                            {
                                uIControler.ActivateScoreDisplay();

                                // Fished game
                                playGame = false;

                                fishedCollcting = false;
                            }
                        }
                    }
                }
            }
        }

        // Inputs

        // Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseResume();
        }
    }



    // UI buttons

    public void StartPlaying()
    {
        uIControler.DeActivateStart();

        waitToStartTimer.StartTimer();

        playGame = true;

    }

    [SerializeField]
    public void PlayAgian()
    {
        // Start getting ready timer
        gettingReadyTimer.StartTimer();

        readyingAnouncment = true;


        playGame = true;

        uIControler.DeActivateScoreDisplay();

        // Retun back to orignal score setup
        if (uIControler.GetSendtScores())
        {
            // Turn ON the just got resulst 
            uIControler.ActivateSentResultsButton();
            uIControler.ActivateJustGotScores();

            // Turn OFF Sent results
            uIControler.DeActivateBackResultsButton();
            uIControler.DeActivateSendtScores();
        }
    }

    [SerializeField]
    public void PauseResume()
    {
        // In menu & in scores
        if (!playGame)
        {
            // Quit
            if (!uIControler.GetQuit())
            {
                uIControler.ActivateQuit();
            }
            else
            {
                uIControler.DeActivateQuit();
            }
        }

        // Playying game
        else
        {
            // Not paused
            if (!paused)
            {
                paused = true;

                // Stop all ground from moving
                settings.stopMovingGround = true;

                uIControler.ActivatePause();
            }

            // Paused
            else
            {
                paused = false;

                // play all ground to move
                settings.stopMovingGround = false;

                uIControler.DeActivatePause();
            }
        }
    }

    [SerializeField]
    public void QuitGame()
    {
        // Temp
        gameDataSaveLoad.Delete();

        // Not Playing game
        if (!playGame)
        {
            // Quit state
            uIControler.DeActivateQuit();
        }

        // Playing game
        else
        {
            // Paused 
            uIControler.DeActivatePause();
        }

        Application.Quit();
    }
}