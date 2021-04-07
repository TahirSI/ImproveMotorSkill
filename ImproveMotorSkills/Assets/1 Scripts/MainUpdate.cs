using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUpdate : MonoBehaviour
{
    // Private
    private bool fishedCollcting;

    private bool practiceState;
    
    private bool practicePlay;
    private bool showIntroCards;
    private bool explaneGameInfoCards;

    private bool practiceAcation;
    
    private int introCardIndex;
    
    private bool readyingAnouncment;
    private bool playGame;
    private bool paused;

    private bool performence;
    private bool interactable;
    private bool inputed;

    private bool acations;
    private bool extendAcations;
    private bool exterdAcPlayer;

    private bool dodged;

    private int practiInputIndex;
    
    private int inputIndex;
    private float[] timesStored = new float[10];

    private bool showNewScoreText;

    
    // Dodgeable object 
    private int dodgedObjectIndex;
    
    
    // External
    private Settings settings;

    [SerializeField]
    private Canvas canvasControl;


    // Game data
    [SerializeField]
    private GameDataControl gameDataControl;
    [SerializeField]
    private GameDataSaveLoad gameDataSaveLoad;

    // Timeres
    private Timer gettingReadyTimer;
    private Timer waitToStartTimer;
    private Timer inputTimer;

    private UIControler uIControler;

    // Dislsyed input
    private InputSelection inputSelctions;
    
    
    // Public
    
    [SerializeField]
    private DisplayedInput displayedInput;
    
    [SerializeField]
    public PlayerAcations playerAcations;

    // Objects to doage
    [SerializeField]
    private MoveDodgable [] objectToDodge;

    
    // Moving text
    [SerializeField]
    private MovingText moveReadyText;
    [SerializeField]
    private MovingText moveGoText;

    [SerializeField]
    private NewHiScoreBlinking newHiScore;

    [SerializeField]
    private CamAcations camAcations;
    
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
        RandmiseInputs();

        // Get the practice input
        RandmisePractInput();
        

        // Dodge object set to reset beging 
        for (var i = 0; i < objectToDodge.Length; i++)
        {
            objectToDodge[i].SetUpStart();   
        }
        

        // Display ready 
        gettingReadyTimer.SetTimerToStopAmount(0.8f);


        // Set wait time - 1 sec
        waitToStartTimer.SetTimerToStopAmount(1);

        // Set input timer
        inputTimer.SetTimerToStopAmount(settings.dodgeTime);


        // Set the dodgale object speed

        // Each grid square is 50px  
        settings.dodgableObjectsSpeed = 50 *
            ((settings.dodgableObjectPernet.transform.position.x - 3) * 2) /
            (100 * settings.dodgeTime);

        // Ground speed to mach
        settings.groundMoveSpeed = settings.dodgableObjectsSpeed;

        // Set the dogable obejct speed
        for (var i = 0; i < objectToDodge.Length; i++)
        {
            objectToDodge[i].SetMoveSpeed(settings.dodgableObjectsSpeed);
        }

        // Check the delete butto active state 
        CheckScoreDelteOnOff();
        
        // Check the all delete butto active state 
        CheckAllDataDelteOnOff();

        // Check ifneed to practice
        CheckPractice();
        
        // Allrdy practiced
        if(!practicePlay)
        {
            // Practice skip button
            uIControler.ActivatePracticeSkip();
        }


        // Set scale to anaime at
        moveReadyText.SetMinMaxScales(settings.readytextScalMinMax.x, settings.readytextScalMinMax.y);

        // Set Go text
        moveGoText.SetMinMaxScales(settings.gotextScalMinMax.x, settings.gotextScalMinMax.y);
        
        uIControler.ActivateStart();
    }

    private void Update()
    {
        // playing game
        if (playGame)
        {
            // Not paused
            if (!paused)
            {
                // Show the startinhg cards 
                if (showIntroCards)
                {
                    if (explaneGameInfoCards)
                    {
                        // Reached the fisrt info card section
                        if (introCardIndex > 6)
                        {
                            explaneGameInfoCards = false;
                            showIntroCards = false;


                            // Pause button in playing game - ON
                            uIControler.ActivatePauseButton();


                            // Decativate left & right arrows
                            uIControler.DeActivateIntroCardsLeftArrowButton();
                            uIControler.DeActivateIntroCardsRightArrowButton();

                            // Actiave practice start button
                            uIControler.ActivateIntroCardsStartButton();

                            // Intro card holder
                            uIControler.DeActivateIntroCradsHolder();

                            // Cam animate in
                            camAcations.AnimateIn();
                        }
                    }
                }
                else
                {
                    if (readyingAnouncment)
                    {
                        if (gettingReadyTimer.GetTimerStillOn())
                        {
                            // Update timer
                            gettingReadyTimer.UpdateTimer();

                            if (!gettingReadyTimer.GetTimerStillOn())
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
                                if (moveReadyText.GetCurrentScale().x >=
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

                                // Input counter
                                uIControler.ActivateInputCounter();

                                // Practcing - OFF
                                if (!practicePlay)
                                {
                                    // Set the input counter text
                                    uIControler.SetInputCounterText(inputIndex + 1, settings.kyes.Length);
                                }
                                else
                                {
                                    // Set the input counter text
                                    uIControler.SetInputCounterText(practiInputIndex + 1, settings.PracticeKey.Length);
                                }


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


                                    // Dodgeable obejct randmises
                                    RandmiseDodgeObject();

                                    // Dodgeable - Activate 
                                    objectToDodge[dodgedObjectIndex].ActivateObject();

                                    // Set pos distnce
                                    displayedInput.SetPosShift(objectToDodge[dodgedObjectIndex].GetInputPosShift());


                                    if (!practicePlay)
                                    {
                                        // Set the disply input
                                        displayedInput.SetImage(settings.inputValues[inputIndex]);
                                    }

                                    // Practicing - ON
                                    else
                                    {
                                        // Set the disply input
                                        displayedInput.SetImage(settings.PracticeInpuValue[practiInputIndex]);
                                    }

                                    displayedInput.ActivateObject();
                                }
                            }
                            else
                            {
                                if (inputTimer.GetTimerStillOn())
                                {
                                    inputTimer.UpdateTimer();

                                    var check = false;

                                    // Key
                                    var setInput = KeyCode.A;

                                    // Practcing - ON
                                    if (practicePlay)
                                    {
                                        // Practice input
                                        setInput = settings.PracticeKey[practiInputIndex];
                                    }
                                    else
                                    {
                                        // In game inputs
                                        setInput = settings.kyes[inputIndex];
                                    }


                                    // If inputed 
                                    if (Input.GetKeyDown(setInput))
                                    {
                                        // Practcing - OFF
                                        if (!practicePlay)
                                        {
                                            // Store data — the input time
                                            timesStored[inputIndex] = inputTimer.GetCurrentTime();
                                        }

                                        // Set the speed ups
                                        objectToDodge[dodgedObjectIndex].SetMoveSpeed(settings.objectsFastSpeed);
                                        settings.groundMoveSpeed = settings.objectsFastSpeed;

                                        inputed = true;

                                        check = true;
                                    }

                                    // Not inputed
                                    if (!inputed)
                                    {
                                        // Input timer reached end
                                        if (inputTimer.TimerReachedEnd())
                                        {
                                            // Practcing - OFF
                                            if (!practicePlay)
                                            {
                                                timesStored[inputIndex] = inputTimer.GetCurrentTime();
                                            }

                                            // Geting hit
                                            playerAcations.ActivateGotHit();

                                            acations = true;

                                            // Checked
                                            check = true;
                                        }
                                    }

                                    // Check 
                                    if (check)
                                    {
                                        inputTimer.ResetTimer();

                                        // Practcing - OFF
                                        if (!practicePlay)
                                        {
                                            inputIndex++;
                                        }

                                        // Practice - ON
                                        else
                                        {
                                            practiInputIndex++;

                                            if (practiInputIndex > settings.PracticeKey.Length - 1)
                                            {
                                                practicePlay = false;

                                                // Long stored practiced game - Check
                                                if (!gameDataControl.GetPracticedGame())
                                                {
                                                    // Set practiced game 
                                                    gameDataControl.SetPracticedGame(true);
                                                }
                                            }

                                            // Acatopn for practice - true
                                            practiceAcation = true;
                                        }

                                        // Decativate displayyed input
                                        displayedInput.DeactivateObject();

                                        interactable = false;

                                        performence = true;
                                    }

                                    // If input reached last one 
                                    if (inputIndex > settings.kyes.Length - 1)
                                    {
                                        fishedCollcting = true;

                                        inputIndex = 0;

                                        float avrageStored = 0;

                                        // Store chnagable storage
                                        for (var i = 0; i < timesStored.Length; i++)
                                        {
                                            // Get avrage
                                            avrageStored += timesStored[i];

                                            gameDataControl.StoreChangeableReults(i, timesStored[i]); // Changimng data

                                            // Set the score chnage texts
                                            uIControler.SetChnageScoresText(i, timesStored[i]);
                                        }

                                        avrageStored = avrageStored / timesStored.Length;


                                        var newHighScore = false;

                                        // If first time colecting
                                        if (!gameDataControl.GetPermanentDataStored())
                                        {
                                            newHighScore = true;
                                        }
                                        else
                                        {
                                            // If new score low score
                                            if (gameDataControl.GetChangeableAvrage() > avrageStored)
                                            {
                                                newHighScore = true;

                                                // Global show new score
                                                showNewScoreText = true;
                                            }
                                        }

                                        if (newHighScore)
                                        {
                                            // Store game data - chnage Avrage
                                            gameDataControl.StoreChangeableAvrage(avrageStored);
                                        }

                                        // Chnage score - avrage
                                        uIControler.SetChangeScoreAvrageText(avrageStored);

                                        // Permanent data - Not stored
                                        if (!gameDataControl.GetPermanentDataStored())
                                        {
                                            for (var i = 0; i < timesStored.Length; i++)
                                            {
                                                // storeing the permant data results
                                                gameDataControl.StorePermanentReults(i, timesStored[i]);

                                                // Set the Diplay scores text
                                                uIControler.SetPermanentScoresText(i, timesStored[i]);
                                            }

                                            // Save data
                                            gameDataControl.StorePermanentAvrage(avrageStored); // Permnet

                                            // Permant storage stored
                                            gameDataControl.SetPermanentDataStorage(true);


                                            // UI - Perment results avrage
                                            uIControler.SetPermanentScoreAvrageText(avrageStored);


                                            CheckScoreDelteOnOff();
                                        }

                                        // Save data
                                        gameDataSaveLoad.SaveData();
                                    }
                                }
                            }
                        }

                        // Dodgable object
                        if (objectToDodge[dodgedObjectIndex].GetObjectActive())
                        {
                            // Update the dodge object
                            objectToDodge[dodgedObjectIndex].UpdateObject();

                            // If inputed
                            if (inputed)
                            {
                                if (objectToDodge[dodgedObjectIndex].GetObjectPos().x < 4)
                                {
                                    // Inputed back to false
                                    inputed = false;

                                    acations = true;
                                    dodged = true;

                                    // Set the speed back to normal
                                    objectToDodge[dodgedObjectIndex].SetMoveSpeed(settings.dodgableObjectsSpeed);
                                    settings.groundMoveSpeed = settings.dodgableObjectsSpeed;

                                    playerAcations.ActivateJump();
                                }
                            }
                        }

                        // Displyed input
                        if (displayedInput.GetAcativeObject())
                        {
                            displayedInput.Move(objectToDodge[dodgedObjectIndex].GetObjectPos());
                        }

                        // Actions need to happen
                        if (acations)
                        {
                            var check = false;

                            // Doged the object
                            if (dodged)
                            {
                                if (!playerAcations.GetIfStillJumping())
                                {
                                    dodged = false;

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

                                // In game playing
                                if (!practiceAcation)
                                {
                                    // Fished collecting scores
                                    if (fishedCollcting)
                                    {
                                        // Pause button in playing game - OFF
                                        uIControler.DeActivatePauseButton();

                                        // Input counter - OFF
                                        uIControler.DeActivateInputCounter();
                                    }
                                }

                                // Practicing - true
                                else
                                {
                                    // If current practice index - max 
                                    if (practiInputIndex > settings.PracticeKey.Length - 1)
                                    {
                                        // Pause button in playing game - OFF
                                        uIControler.DeActivatePauseButton();

                                        // Input counter - OFF
                                        uIControler.DeActivateInputCounter();
                                    }
                                }

                                // In game - results collceting
                                if (!practiceAcation)
                                {
                                    // Not coled all results
                                    if (!fishedCollcting)
                                    {
                                        waitToStartTimer.StartTimer();

                                        // Set the input counter text
                                        uIControler.SetInputCounterText(inputIndex + 1, settings.kyes.Length);
                                    }

                                    // Fished collection
                                    else
                                    {
                                        // Show new scores
                                        if (showNewScoreText)
                                        {
                                            // Actiave new high score
                                            uIControler.ActivateNewHighScore();

                                            newHiScore.GetTimer().StartTimer();
                                        }


                                        // Scores
                                        uIControler.ActivateScoresDisplay();

                                        // Score Menu - OFF
                                        uIControler.DeActivateScoresInMenu();

                                        // Scores Results - ON
                                        uIControler.ActivateScoresInResults();


                                        // Fished game
                                        playGame = false;

                                        fishedCollcting = false;

                                        // Cam animate OUT
                                        camAcations.AnimateOut();


                                        // Game was played fisrt time - false
                                        if (!gameDataControl.GetPlayedFistTime())
                                        {
                                            // Prevuse Intro card - OFF
                                            uIControler.DeActivateIntroCrads(introCardIndex);


                                            introCardIndex = uIControler.GetIntroCardsSize() - 1;

                                            // Thnak you intro cards - ON
                                            uIControler.ActivateIntroCrads(introCardIndex);


                                            // Decativate left & right arrows
                                            uIControler.DeActivateIntroCardsLeftArrowButton();
                                            uIControler.DeActivateIntroCardsRightArrowButton();


                                            // Practice Start button - OFF
                                            uIControler.DeActivateIntroCardsStartButton();

                                            // Got it button - ON
                                            uIControler.ActivateIntroCardsGotItButton();

                                            // Intro card holder
                                            uIControler.ActivateIntroCradsHolder();


                                            // Turn on played game fisrt time 
                                            gameDataControl.SetPlayedFistTime(true);
                                        }
                                    }
                                }

                                // Practcing action - ON
                                else
                                {
                                    if (practiInputIndex < settings.PracticeKey.Length)
                                    {
                                        waitToStartTimer.StartTimer();
                                    }

                                    // Set the input counter text
                                    uIControler.SetInputCounterText(practiInputIndex + 1, settings.PracticeKey.Length);


                                    if (practiInputIndex > settings.PracticeKey.Length - 1)
                                    {
                                        // Reading the anouncements
                                        readyingAnouncment = true;

                                        // Start getting ready timer
                                        gettingReadyTimer.StartTimer();


                                        // Rest index
                                        practiInputIndex = 0;

                                        // Other section
                                        explaneGameInfoCards = false;

                                        showIntroCards = true;


                                        // Intro cards holder
                                        uIControler.ActivateIntroCradsHolder();
                                    }

                                    // Actiopn for practice - False
                                    practiceAcation = false;
                                }
                            }
                        }
                    }
                }
            }
        }


        // If in mid acation
        if (extendAcations)
        {
            if (exterdAcPlayer)
            {
                // Doged the object
                if (dodged)
                {
                    if (!playerAcations.GetIfStillJumping())
                    {
                        dodged = false;

                        exterdAcPlayer = false;
                    }
                }
                // Hit the object
                else
                {
                    playerAcations.UpdateGotHit();

                    if (!playerAcations.GetStillHiting())
                    {
                        exterdAcPlayer = false;
                    }
                }
            }

            var check = false;

            // Dodgable object
            if (objectToDodge[dodgedObjectIndex].GetObjectActive())
            {
                // Update the dodge object
                objectToDodge[dodgedObjectIndex].UpdateObject();

                // Stoped fadeing
                if (!objectToDodge[dodgedObjectIndex].GetFadeding())
                {
                    objectToDodge[dodgedObjectIndex].ResetMoveObject();

                    check = true;
                }
            }

            // Exepation for obejcts reaching end point
            else
            {
                // Rest move objetc
                objectToDodge[dodgedObjectIndex].ResetMoveObject();

                // Reset fade object
                objectToDodge[dodgedObjectIndex].ResetFadedObject();


                check = true;
            }

            if (check && !exterdAcPlayer)
            {
                extendAcations = false;

                // Start menu - actiave
                uIControler.ActivateStart();
            }
        }


        // If new high score ON
        if (uIControler.GetNewHighScore())
        {
            // Update
            newHiScore.UpdateNewHighScore();
        }


        // Camer acations
        if (camAcations.GetAnimating())
        {
            camAcations.UpdateCam();
        }


        // Inputs

        // Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseResume();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (explaneGameInfoCards)
            {
                // Reached the fisrt info card section
                if (introCardIndex <= 6)
                {
                    PrevuseInfoCardButton();
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (explaneGameInfoCards)
            {
                // Reached the fisrt info card section
                if (introCardIndex <= 6)
                {
                    NextInfoCardButton();
                }
            }
        }
    }


    // Quit aplaication
    private void OnApplicationQuit()
    {
        canvasControl.renderMode = RenderMode.ScreenSpaceCamera;
    }

    
    
    // Extra functions
    
    // Randmise
    private void RandmiseInputs()
    {
        for (var i = 0; i < settings.kyes.Length; i++)
        {
            // Get the rand value
            settings.inputValues[i] = inputSelctions.GetRandNumber(0, 25);

            // Set the rand key based on the value
            settings.kyes[i] = inputSelctions.GetRandInout(settings.inputValues[i]);
        }
    }

    private void RandmisePractInput()
    {
        for (int i = 0; i < settings.PracticeKey.Length; i++)
        {
            settings.PracticeInpuValue[i] = inputSelctions.GetRandNumber(0, 25);

            settings.PracticeKey[i] = inputSelctions.GetRandInout(settings.PracticeInpuValue[i]);   
        }
    }
    
    
    // Reset
    private void ResetTempScores()
    {
        // Store data — the input time
        for (var i = 0; i < timesStored.Length; i++)
        {
            timesStored[i] = 0;

            // UI set score
            uIControler.SetChnageScoresText(i, timesStored[i]);   
        }
    }

    private void ScoresStateReset()
    {
        uIControler.DeActivateScoresDisplay();

        // New high score ON
        if (uIControler.GetNewHighScore())
        {
            // Deacativate New high score
            newHiScore.ResetNewHighScore();
        }
        
        // Retun back to orignal score setup
        if (uIControler.GetPermanenttScores())
        {
            // Turn ON the chnage scores
            uIControler.ActivateChnageScores();

            // Turn OFF perment results
            uIControler.DeActivatePermanenttScores();
        }   
    }

    // Practiceing
    private void CheckPractice()
    {
        // Practicing check
        practicePlay = !gameDataControl.GetPracticedGame();;
        
        if (practicePlay)
        {
            // Practice state for all practice staes - true
            practiceState = true;
            
            // Show the strt cards
            showIntroCards = true;
            
            explaneGameInfoCards = true;
            
            uIControler.ActivateIntroCrads(introCardIndex);

            // Practice off - OFF
            uIControler.GetPracticeOffObject().GetComponent<Button>().interactable = false;
        }
    }

    private void ResetIntroCardsSetUp()
    {
        // turn off the curent card
        uIControler.DeActivateIntroCrads(introCardIndex);

        // Back to start
        uIControler.ActivateIntroCrads(0);
        
        
        
        // Intro cards start - OFF
        uIControler.DeActivateIntroCardsStartButton();
        
        // Intro  cards Got it - OFF
        uIControler.DeActivateIntroCardsGotItButton();
        
        // Arrow bittons - ON
        uIControler.ActivateIntroCardsLeftArrowButton();
        uIControler.ActivateIntroCardsRightArrowButton();
        
        // Intro cards holder - OFF
        uIControler.DeActivateIntroCradsHolder();
        
        // index = 0
        introCardIndex = 0;

        // Practicing check
        CheckPractice();
    }

    private void RandmiseDodgeObject()
    {
        if (objectToDodge.Length > 1)
        {
            dodgedObjectIndex = inputSelctions.GetRandNumber(0, objectToDodge.Length);
        }
    }

    
    // UI buttons

    private void RestGameData(bool all_data)
    {
        gameDataControl.RestGameData(all_data);
    }
    
    public void ScoresUpdateLocalData()
    {
        for (var i = 0; i < timesStored.Length; i++)
        {
            // Changable storage 
            uIControler.SetChnageScoresText(i, gameDataControl.GetChangeableReults(i));

            // Permanate storage
            uIControler.SetPermanentScoresText(i, gameDataControl.GetPermanentReults(i));
        }
        
        // Avrage - Changable
        uIControler.SetChangeScoreAvrageText(gameDataControl.GetChangeableAvrage());
        
        // Avrage - Permanate
        uIControler.SetPermanentScoreAvrageText(gameDataControl.GetPermanentAvrage());
    }
    
    public void DisplayScoresMenu()
    {
        ScoresUpdateLocalData();
            
        // scores Results - OFF
        uIControler.DeActivateScoresInResults();
        
        // scores Menu - ON
        uIControler.ActivateScoresInMenu();
    }

    public void DeleteScores()
    {
        // If stored any other data
        if (gameDataControl.GetPermanentDataStored())
        {
            // Rest score data
            RestGameData(false);

            // Updat saved file
            gameDataSaveLoad.SaveData();
            
            // Upadat local data
            ScoresUpdateLocalData();
            
            // Deactiveate delete button
            CheckScoreDelteOnOff();
        }
    }

    public void DeletAllSavedData()
    {
        // Rest score data
        RestGameData(true);
        
        gameDataSaveLoad.Delete();

        
        // Check delete all data button
        CheckAllDataDelteOnOff();
        
        // Check delete all data button
        CheckAllDataDelteOnOff();

        // Rests info card holder
        ResetIntroCardsSetUp();
        
        
        // Practice skip button
        uIControler.DeActivatePracticeSkip();
    }
    

    // ReSharper disable Unity.PerformanceAnalysis
    private void CheckScoreDelteOnOff()
    {
        if (gameDataControl.GetChangeableAvrage() > 0)
        {
            uIControler.GetScoresDeleteGameObject().GetComponent<Button>().interactable = true;
        }
        else
        {
            uIControler.GetScoresDeleteGameObject().GetComponent<Button>().interactable = false;
        }
    }
    
    
    private void CheckAllDataDelteOnOff()
    { 
        uIControler.GetAllDataDeleteGameObject().GetComponent<Button>().interactable = 
            gameDataControl.GetPracticedGame();
    }
    

    public void DisplayNewHighScore()
    {
        if (uIControler.GetChnageScores())
        {
            // Turn OFF chnage scores
            uIControler.DeActivateChnageScores();

            // Turn ON permant scores
            uIControler.ActivatePermanenttScores();

            if (showNewScoreText)
            {
                // New high score - Reset
                newHiScore.ResetNewHighScore();   
            }
        }
        else if (uIControler.GetPermanenttScores())
        {
            // Turn ON chnage scores
            uIControler.ActivateChnageScores();

            // Turn OFF permant scores
            uIControler.DeActivatePermanenttScores();

            if (showNewScoreText)
            {
                // New high score - ON
                uIControler.ActivateNewHighScore();
            
                // Start timer 
                newHiScore.GetTimer().StartTimer();
            }
        }
    }
    
    
    // Practice ON / OFF switch
    public void PracticeSwitchButton()
    {
        // Has not practiced
        if (gameDataControl.GetPracticedGame())
        {
            // If OFF - is active
            if (uIControler.GetPracticeOff())
            {
                practicePlay = true;

                // Practice state = true
                practiceState = true;
                
                
                // Practive OFF - OFF
                uIControler.DeActivatePracticeOff();
                
                // Practice on - ON
                uIControler.ActivatePracticeOn();

                // Practice skip button - ON
                uIControler.ActivatePracticeSkip();
            }
            else if (uIControler.GetPracticeOn())
            {
                practicePlay = false;

                // Practice state = true
                practiceState = false;                
                
                
                // Practice on - OFF
                uIControler.DeActivatePracticeOn();
                
                // Practive OFF - ON
                uIControler.ActivatePracticeOff();
            }
        }
    }

    // Practiceskip 
    public void PracticeSkipButton()
    {
        uIControler.DeActivateIntroCrads(introCardIndex);
        
        introCardIndex = 6;
        
        uIControler.ActivateIntroCrads(introCardIndex);

        uIControler.DeActivatePracticeSkip();
    }
    
    
    // Info card buttons

    // If whant to practice
    public void PracticeGameButton()
    {
        practicePlay = true;

        // Practice state = true
        practiceState = true;
        
        
        // Show the strt cards
        showIntroCards = true;
            
        explaneGameInfoCards = true;
    }
    
    // Back
    public void PrevuseInfoCardButton()
    {
        // prevuse Intro card - OFF
        uIControler.DeActivateIntroCrads(introCardIndex);   

        // dicrement
        introCardIndex--;
        
        if (introCardIndex < 0)
        {
            introCardIndex = 0;
        }

        // Has practiced
        if (gameDataControl.GetPracticedGame())
        {
            if (introCardIndex > 4 && introCardIndex <= 5)
            {
                // Practice skip button
                uIControler.ActivatePracticeSkip();
            }
        }

        // The cureent info card - ON
        uIControler.ActivateIntroCrads(introCardIndex);

        if (introCardIndex <= 0)
        {
            // Go mack to menu
            Menu();
        }
    }
    
    // Next
    public void NextInfoCardButton()
    {
        // Prevuse Intro card - OFF
        uIControler.DeActivateIntroCrads(introCardIndex);
        
        introCardIndex++;

        // Has not practiced
        if (gameDataControl.GetPracticedGame())
        {
            if (introCardIndex > 5 && introCardIndex <= 6)
            {
                // Practice skip button
                uIControler.DeActivatePracticeSkip();
            }   
        }

        // Next intro cards - ON
        uIControler.ActivateIntroCrads(introCardIndex);
        
    }

    
    // Practice Start button
    public void FishedPracticingStart()
    {
        if (!gameDataControl.GetPlayedFistTime())
        {
            // Prevuse Intro card - OFF
            uIControler.DeActivateIntroCrads(introCardIndex);

        
            introCardIndex++;
        
            // Next intro cards - ON
            uIControler.ActivateIntroCrads(introCardIndex);
        
        
            // Practice Start button - OFF
            uIControler.DeActivateIntroCardsStartButton();

            // Got it button - ON
            uIControler.ActivateIntroCardsGotItButton();
        }
        else
        {
            ResetIntroCardsSetUp();
        }

        // Practice OFF - actiavte button
        uIControler.GetPracticeOffObject().GetComponent<Button>().interactable = true;
                                            
        // Practice OFF - ON
        uIControler.ActivatePracticeOff();
                                                
        // Practice ON - OFF
        uIControler.DeActivatePracticeOn();
        
        

        // Intro cards holder - OFF
        uIControler.DeActivateIntroCradsHolder();
        
        
        // Show cards - OFF
        showIntroCards = false;

        // Practice inputed - OFF
        practiceAcation = false;
        
        // Practiseing state - OFF
        practiceState = false;
        
        
        // Cam animate in
        camAcations.AnimateIn();
        
        
        // Pause button in playing game - ON
        uIControler.ActivatePauseButton();
    }
    
    // Got it button - when fisrt time played 
    public void GotItButton()
    {
        // Rest into cards
        ResetIntroCardsSetUp();

        // Randmise practice cards
        RandmisePractInput();
    }
    
    
    // Menu buttons
    public void StartPlaying()
    {
        uIControler.DeActivateStart();

        // Reading the anouncements
        readyingAnouncment = true;

        // Start getting ready timer
        gettingReadyTimer.StartTimer();


        // Practiving state - ON
        if (practiceState)
        {
            // Practice playing - true
            if (practicePlay)
            {
                // Activate into cards holder
                uIControler.ActivateIntroCradsHolder();
            
                // Into crads - ON
                uIControler.ActivateIntroCrads(introCardIndex);
            
            
                showIntroCards = true;
                explaneGameInfoCards = true;
                
                // Has practiced
                if (gameDataControl.GetPracticedGame() && !practiceAcation)
                {
                    uIControler.ActivatePracticeSkip();
                } 
            }
            
            // Practiced plating
            else
            {
                // Activate into cards holder
                uIControler.ActivateIntroCradsHolder();
                
                
                // Curreny info card - False 
                uIControler.DeActivateIntroCrads(introCardIndex);
        
                // Set the info card to practiced
                introCardIndex = 7;
        
                uIControler.ActivateIntroCrads(introCardIndex);
                
                
                // Decativate left & right arrows
                uIControler.DeActivateIntroCardsLeftArrowButton();
                uIControler.DeActivateIntroCardsRightArrowButton();
        
                // Actiave practice start button
                uIControler.ActivateIntroCardsStartButton();
                
                
                showIntroCards = true;
            }
        }
        else
        {
            // Pause button in playing game - ON
            uIControler.ActivatePauseButton();
            
            // Cam animate IN
            camAcations.AnimateIn();
        }

        // play active
        playGame = true;
    }

    public void Menu()
    {
        if (playGame)
        {
            // If in readying game
            if (readyingAnouncment)
            {
                // If gettingready timer is ON
                if (!gettingReadyTimer.GetTimerStillOn())
                {
                    // Ready text is ON 
                    if (uIControler.GetReadyText())
                    {
                        // reset
                        moveReadyText.ResetText();
                    }

                    // Go text is ON
                    if (uIControler.GetGoText())
                    {
                        // reset
                        moveGoText.ResetText();
                    }

                    // Turn OFF Anoincemnts
                    uIControler.DeActivateAnoucments();
                }
                
                gettingReadyTimer.ResetTimer();

                uIControler.ActivateStart();
            }

            // In game
            else
            {
                // If timer is on
                if (waitToStartTimer.GetTimerStillOn())
                {
                    waitToStartTimer.ResetTimer();
                }

                // Not doing an acation 
                if (!acations)
                {
                    // Decativate displayyed input
                    displayedInput.DeactivateObject();

                    // Start menu - actiave
                    uIControler.ActivateStart();
                } 

                // Acations
                else
                {
                    if (dodged)
                    {
                        playerAcations.GETHitRoataing().bodyType = RigidbodyType2D.Dynamic;
                    }
                }
                
                // Continue acation;
                extendAcations = true;
                
                
                // Dodge objects acative
                if (objectToDodge[dodgedObjectIndex].GetObjectActive())
                {
                    // Extened player acation
                    exterdAcPlayer = true;
                    
                    
                    // Set the speed back to normal
                    objectToDodge[dodgedObjectIndex].SetMoveSpeed(settings.dodgableObjectsSpeed);
                    settings.groundMoveSpeed = settings.dodgableObjectsSpeed;

                    // Reset dodge object
                    objectToDodge[dodgedObjectIndex].ActiaveFadeOutObject();   
                }

                // Input counter - OFF
                uIControler.DeActivateInputCounter();
                
                
                // Input timer
                inputTimer.ResetTimer();
                
                // Reset the temp score values
                ResetTempScores();
            }

            // Pause button in playing game - OFF
            uIControler.DeActivatePauseButton();


            // Reset  practiceinput index
            practiInputIndex = 0;
            
            // Reset input index
            inputIndex = 0;
            
            
            acations = false;

            fishedCollcting = false;

            
            inputed = false;
            
            paused = false;
            
            // play all ground to move
            settings.stopMovingGround = false;
            
            
            readyingAnouncment = false;
            
            interactable = false;

            performence = false;

            playGame = false;
            
            
            // Cam animate OUT
            camAcations.AnimateOut();
            
            // Deacativate pause
            uIControler.DeActivatePauseHolder();


            // pracie action - ON
            if (practiceAcation)
            {
                // Into cards holder - OFF
                uIControler.DeActivateIntroCradsHolder();
            
                // Into crads - OFF
                uIControler.DeActivateIntroCrads(introCardIndex);

                practiceAcation = false;
            }
            
            // Player animations - ON
            playerAcations.ReactivateAnimation();
        }
        
        // Results state
        else
        {
            showNewScoreText = false;

            // Reset scores screen
            ScoresStateReset();
            
            // Start screen
            uIControler.ActivateStart();
        }
        
        // Practiving play - OFF
        if (!practicePlay)
        {
            // Randmise input
            RandmiseInputs();
            
            
            // Practice ON - OFF
            uIControler.DeActivatePracticeOn();
                    
            // Practice OFF - ON
            uIControler.ActivatePracticeOff();
        }
        else
        {
            if (gameDataControl.GetPracticedGame())
            {
                // Practice state for practicing - false
                practiceState = false;
                
                // Practicing play - false
                practicePlay = false;

                // Show cards - false
                showIntroCards = false;

                
                // Has practiced
                if (gameDataControl.GetPracticedGame() && !practiceAcation)
                {
                    // Skip button - false
                    uIControler.DeActivatePracticeSkip();
                } 
                
                // Practice ON - OFF
                uIControler.DeActivatePracticeOn();
                    
                // Practice OFF - ON
                uIControler.ActivatePracticeOff();
            }
            
            // Randmise practice input
            RandmisePractInput();
        }

        CheckAllDataDelteOnOff();
        
        ResetIntroCardsSetUp();
    }

    public void PlayAgian()
    {
        // Start getting ready timer
        gettingReadyTimer.StartTimer();

        readyingAnouncment = true;
        
        playGame = true;

        showNewScoreText = false;
        
        
        // Pause button in playing game - ON
        uIControler.ActivatePauseButton();

        // Randmise input
        RandmiseInputs();
        
        // Reset the temp score values
        ResetTempScores();
        
        // Puts back the score stae the way it was & deacativate it
        ScoresStateReset();
        
        // Cam animate IN
        camAcations.AnimateIn();
    }

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

                if (dodged)
                {
                    playerAcations.GETHitRoataing().bodyType = RigidbodyType2D.Static;
                }

                // Paise holder - True
                uIControler.ActivatePauseHolder();
            }

            // Paused
            else
            {
                paused = false;

                // play all ground to move
                settings.stopMovingGround = false;

                if (dodged)
                {
                    playerAcations.GETHitRoataing().bodyType = RigidbodyType2D.Dynamic;
                }

                // Pause holder - False
                uIControler.DeActivatePauseHolder();
            }

            // Pause / unPause naiamtion
            playerAcations.PauseAnimationSwitch();
        }
    }

    public void QuitGame()
    {
        canvasControl.renderMode = RenderMode.ScreenSpaceCamera;

        Application.Quit();
    }
}