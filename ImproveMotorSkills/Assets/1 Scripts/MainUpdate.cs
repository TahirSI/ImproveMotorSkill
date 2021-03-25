using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUpdate : MonoBehaviour
{
    // Private
    private bool fishedCollcting;

    private bool practice;
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

    private bool dodged;

    private int practiInputIndex;
    
    private int inputIndex;
    private float[] timesStored = new float[10];

    private bool showNewScoreText;

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

    public NewHiScoreBlinking newHiScore;

    public CamAcations camAcations;
    
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


        // Set pos des
        displayedInput.SetPosShift(new Vector3(0, 2.5f, 0));
        
        // Dodge object set to reset beging 
        objectToDodge.SetBegingPos();
        
        
        // Display ready 
        gettingReadyTimer.timerToStopAt = 0.8f;


        // Set wait time - 1 sec
        waitToStartTimer.timerToStopAt = 1;

        // Set input timer
        inputTimer.timerToStopAt = settings.dodgeTime;


        // Set the dodgale object speed

        // Each grid square is 50px  
        settings.dodgableObjectsSpeed = 50 *
            ((settings.dodgableObjectPernet.transform.position.x - 3) * 2) /
            (100 * settings.dodgeTime);

        // Ground speed to mach
        settings.groundMoveSpeed = settings.dodgableObjectsSpeed;

        // Set the dogable obejct speed
        objectToDodge.speed = settings.dodgableObjectsSpeed;

        
        // Practicing sestion
        practice = !gameDataControl.GetPracticedGame();
        
        if (practice)
        {
            // Show the strt cards
            showIntroCards = true;
            
            explaneGameInfoCards = true;
            
            uIControler.ActivateIntroCrads(introCardIndex);

            // Practice off - OFF
            uIControler.GetPracticeOffObject().GetComponent<Button>().interactable = false;
        }
        else
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
                        if (introCardIndex > 7)
                        {
                            explaneGameInfoCards = false;
                            showIntroCards = false;
                            
                            // Cam animate IN
                            camAcations.AnimateIn();
                            
                            // Pause button in playing game - ON
                            uIControler.ActivatePauseButton();
                            
                            
                            // Decativate left & right arrows
                            uIControler.DeActivateIntroCardsLeftArrowButton();
                            uIControler.DeActivateIntroCardsRightArrowButton();
        
                            // Actiave practice start button
                            uIControler.ActivateIntroCardsStartButton();
                            
                            // Intro card holder
                            uIControler.DeActivateIntroCradsHolder();
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


                                // Practcing - OFF
                                if (!practice)
                                {
                                    // Input counter
                                    uIControler.ActivateInputCounter();

                                    // Set the input counter text
                                    uIControler.SetInputCounterText(inputIndex + 1);
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

                                    objectToDodge.ActivateObject();


                                    if (!practice)
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
                                    if (practice)
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
                                        if (!practice)
                                        {
                                            // Store data — the input time
                                            timesStored[inputIndex] = inputTimer.GetCurrentTime();   
                                        }

                                        // Set the speed ups
                                        objectToDodge.speed = settings.objectsFastSpeed;
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
                                            if (!practice)
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
                                        if (!practice)
                                        {
                                            inputIndex++;
                                        }

                                        // Practice - ON
                                        else
                                        {
                                            practiInputIndex++;

                                            if (practiInputIndex > settings.PracticeKey.Length - 1)
                                            {
                                                practice = false;

                                                // Practiced game - Check
                                                if (!gameDataControl.GetPracticedGame())
                                                {
                                                    // Set practiced game 
                                                    gameDataControl.SetPracticedGame(true);
                                                }
                                                
                                                // Practice OFF - actiavte button
                                                uIControler.GetPracticeOffObject().GetComponent<Button>().interactable = true;
                                            
                                                // Practice OFF - ON
                                                uIControler.ActivatePracticeOff();
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
                                    dodged = true;

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

                                
                                // In game - results collceting
                                if (!practiceAcation)
                                {
                                    // Not coled all results
                                    if (!fishedCollcting)
                                    {
                                        waitToStartTimer.StartTimer();

                                        // Set the input counter text
                                        uIControler.SetInputCounterText(inputIndex + 1);
                                        
                                    }

                                    // Fished collection
                                    else
                                    {
                                        // Show new scores
                                        if (showNewScoreText)
                                        {
                                            // Actiave new high score
                                            uIControler.ActivateNewHighScore();

                                            newHiScore.timer.StartTimer();
                                        }

                                        // Pause button in playing game - OFF
                                        uIControler.DeActivatePauseButton();

                                        // Input counter - OFF
                                        uIControler.DeActivateInputCounter();


                                        // Scores
                                        uIControler.ActivateScoresDisplay();

                                        // scores Results - ON
                                        uIControler.ActivateScoresInResults();

                                        // scores Menu - OFF
                                        uIControler.DeActivateScoresInMenu();

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

                                    if (practiInputIndex > settings.PracticeKey.Length - 1)
                                    {
                                        // Reading the anouncements
                                        readyingAnouncment = true;

                                        // Start getting ready timer
                                        gettingReadyTimer.StartTimer();
                                        
                                        // Pause button in playing game - OFF
                                        uIControler.DeActivatePauseButton();
                                        
                                        // Rest index
                                        practiInputIndex = 0;

                                        // Other section
                                        explaneGameInfoCards = false;

                                        showIntroCards = true;

                                        // Intro cards holder
                                        uIControler.ActivateIntroCradsHolder();
                                    }
                                    
                                    // Acatopn for practice - False
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
            
            // Dodgable object
            if (objectToDodge.GetObjectActive())
            {
                // Update the dodge object
                objectToDodge.UpdateObject();
            }
            

            if (check)
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
    }

    
    // Quit aplaication
    private void OnApplicationQuit()
    {
        // Temp
        gameDataSaveLoad.Delete();
        
        showNewScoreText = false;
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

    private void ResetIntroCardsSetUp()
    {
        // turrn off the curent card
        uIControler.DeActivateIntroCrads(introCardIndex);

        // Back to start
        uIControler.ActivateIntroCrads(0);
        
        
        
        // Intro cards start - OFF
        uIControler.DeActivateIntroCardsStartButton();
        
        // Intro  ards Got it - OFF
        uIControler.DeActivateIntroCardsGotItButton();
        
        // Arrow bittons - ON
        uIControler.ActivateIntroCardsLeftArrowButton();
        uIControler.ActivateIntroCardsRightArrowButton();
        
        // Intro cards holder - OFF
        uIControler.DeActivateIntroCradsHolder();
        
        // index = 0
        introCardIndex = 0;
    }
    
    
    // UI buttons

    public void DisplayScoresMenu()
    { 
        for (var i = 0; i < timesStored.Length; i++)
        {
            // Changable storage 
            uIControler.SetChnageScoresText(i, gameDataControl.GetChangeableReults(i));
            
            // Avrage - Changable
            uIControler.SetChangeScoreAvrageText(gameDataControl.GetChangeableAvrage());
            
            // Permanate storage
            uIControler.SetPermanentScoresText(i, gameDataControl.GetPermanentReults(i));
            
            // Avrage - Permanate
            uIControler.SetPermanentScoreAvrageText(gameDataControl.GetPermanentAvrage());
        }
        
        // scores Results - OFF
        uIControler.DeActivateScoresInResults();
        
        // scores Menu - ON
        uIControler.ActivateScoresInMenu();
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
                newHiScore.timer.StartTimer();
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
                practice = true;
                
                // Practive OFF - OFF
                uIControler.DeActivatePracticeOff();
                
                // Practice on - ON
                uIControler.ActivatePracticeOn();

                // Practice skip button - ON
                uIControler.ActivatePracticeSkip();
            }
            else if (uIControler.GetPracticeOn())
            {
                practice = false;
                
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
        
        introCardIndex = 7;
        
        uIControler.ActivateIntroCrads(introCardIndex);

        uIControler.DeActivatePracticeSkip();
    }
    
    
    // Info card buttons

    // If what to practice
    public void PracticeGameButton()
    {
        practice = true;
        
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
            if (introCardIndex <= 0)
            {
                if (gameDataControl.GetPracticedGame())
                {
                    // Practice skip button
                    uIControler.ActivatePracticeSkip();
                }
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
    
    // Nect
    public void NextInfoCardButton()
    {
        // Prevuse Intro card - OFF
        uIControler.DeActivateIntroCrads(introCardIndex);
        
        introCardIndex++;

        if (introCardIndex > uIControler.introCards.Length)
        {
            introCardIndex = uIControler.introCards.Length;
        }

        // Has not practiced
        if (gameDataControl.GetPracticedGame())
        {
            if (introCardIndex > 6 && introCardIndex <= 7)
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


        // Intro cards holder - OFF
        uIControler.DeActivateIntroCradsHolder();
        
        
        // Show cards - OFF
        showIntroCards = false;

        // Practice inputed - OFF
        practiceAcation = false;
        
        
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
    
    
    public void StartPlaying()
    {
        uIControler.DeActivateStart();

        // Reading the anouncements
        readyingAnouncment = true;

        // Start getting ready timer
        gettingReadyTimer.StartTimer();


        // Practiving - ON
        if (practice)
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
        else
        {
            // pracie actions - ON
            if (practiceAcation)
            {
                // Activate into cards holder
                uIControler.ActivateIntroCradsHolder();
            
                // Into crads - ON
                uIControler.ActivateIntroCrads(introCardIndex);
            
            
                showIntroCards = true;
            }
            else
            {
                // Pause button in playing game - ON
                uIControler.ActivatePauseButton();
            
                // Cam animate IN
                camAcations.AnimateIn();
            }
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
                    // Set the speed back to normal
                    objectToDodge.speed = settings.dodgableObjectsSpeed;
                    settings.groundMoveSpeed = settings.dodgableObjectsSpeed;

                    // Reset dodge object
                    objectToDodge.ResetObject();

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
                    
                    // Continue acation;
                    extendAcations = true;
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
            uIControler.DeActivatePause();


            // pracie action - ON
            if (practiceAcation)
            {
                // Into cards holder - OFF
                uIControler.DeActivateIntroCradsHolder();
            
                // Into crads - OFF
                uIControler.DeActivateIntroCrads(introCardIndex);

                practiceAcation = false;
            }
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
        
        // Practiving - OFF
        if (!practice)
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
                practice = false;
                
                // Practice ON - OFF
                uIControler.DeActivatePracticeOn();
                    
                // Practice OFF - ON
                uIControler.ActivatePracticeOff();
            }
            
            // Randmise practice input
            RandmisePractInput();
        }
        
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
                
                uIControler.ActivatePause();
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
                
                uIControler.DeActivatePause();
            }
        }
    }

    public void QuitGame()
    {
        // Temp
        gameDataSaveLoad.Delete();
        
        Debug.Log("On quit");
        
        showNewScoreText = false;

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