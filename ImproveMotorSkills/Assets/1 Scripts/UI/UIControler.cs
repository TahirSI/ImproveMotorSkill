using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{
    public Settings settings;
    
    // Start
    public GameObject start;

    // Pause
    public GameObject paused;

    // Quit
    public GameObject quit;

    
    // Practice
    
    // swithc
    public GameObject practiceOFF;  // OFF
    public GameObject practiceON;  // ON

    public GameObject practiceSkip;
    

    // Diplaying text - anoucment
    public GameObject anoucments;
    public GameObject readyText;
    public GameObject goText;

    
    // Intro crds - practice attempt
    public GameObject introCradsHolder;
    public GameObject[] introCards;

    public GameObject introCardsLeftArrowButton;
    public GameObject introCardsRightArrowButton;
    
    public GameObject introCardsStartButton;
    public GameObject introCardsGotItButton;

    
    // input counter
    public GameObject inputCounter;
    public Text inputCounterText;
    
    
    // Scores
    public GameObject soresDisplay;

    // Panles
    public GameObject chnageScores;
    public GameObject permanenttScores;

    // Score texts
    public Text [] scoresChnageText;
    public Text [] scorePermntText;
    
    public Text scoresChnageAvrageText;     // Avrage - chnage
    public Text scoresPermntAvrageText;     // Avrage - permenat

    public GameObject newHighScore;
    
    
    
    // Diffrent secetions for buttons
    public GameObject scoresInResults;
    public GameObject scoresInMenu;
    
    // Buttons
    public GameObject scoresBackToMenuButton;

    public GameObject pauseButton;
    
    
    // Set Scores
    #region Set results/scores
    
    // Displau score
    public void SetChnageScoresText(int index, float amount)
    {
        var text = "";

        if (amount >= settings.dodgeTime)
        {
            text = "Missed";
        }
        else
        {
            text = amount.ToString(CultureInfo.InvariantCulture);
        }
        
        scoresChnageText[index].text = text;
    }
    
    public void SetPermanentScoresText(int index, float amount)
    {
        var text = "";

        if (amount >= settings.dodgeTime)
        {
            text = "Missed";
        }
        else
        {
            text = amount.ToString(CultureInfo.InvariantCulture);
        }
        
        scorePermntText[index].text = text;
    }

    // Avrages
    public void SetChangeScoreAvrageText(float amount)
    {
        scoresChnageAvrageText.text = amount.ToString(CultureInfo.InvariantCulture);
    }       // Change
    public void SetPermanentScoreAvrageText(float amount)
    {
        scoresPermntAvrageText.text = amount.ToString(CultureInfo.InvariantCulture);
    }   // Permant
    
    #endregion
    
    
    // Input counter
    public void ActivateInputCounter()
    {
        inputCounter.SetActive(true);
    }
    
    public void DeActivateInputCounter()
    {
        inputCounter.SetActive(false);
    }
    
    public bool GeInputCounter()
    {
        return inputCounter;
    }

    // Input counter text
    public void SetInputCounterText(int count)
    {
        var text = "";

        if (count < 10)
        {
            text = "0" + count.ToString();
        }
        else
        {
            text = count.ToString();
        }
        
        inputCounterText.text = text + " / " + settings.inputValues.Length.ToString();
    }
    
    
    
    // Actions

    #region Practice

    // Switch
    
    // practice OFF
    public void ActivatePracticeOff()
    {
        practiceOFF.SetActive(true);
    }

    public void DeActivatePracticeOff()
    {
        practiceOFF.SetActive(false);
    }

    public bool GetPracticeOff()
    {
        return practiceOFF.activeSelf;
    }
    
    public GameObject GetPracticeOffObject()
    {
        return practiceOFF;
    }
    
    // practice ON
    public void ActivatePracticeOn()
    {
        practiceON.SetActive(true);
    }

    public void DeActivatePracticeOn()
    {
        practiceON.SetActive(false);
    }

    public bool GetPracticeOn()
    {
        return practiceON.activeSelf;
    }

    public GameObject GetPracticeOnObject()
    {
        return practiceON;
    }
    
    
    // Practice slip 
    public void ActivatePracticeSkip()
    {
        practiceSkip.SetActive(true);
    }

    public void DeActivatePracticeSkip()
    {
        practiceSkip.SetActive(false);
    }

    public bool GetPracticeSkip()
    {
        return practiceSkip.activeSelf;
    }
    
    #endregion
    
    
    #region States
    
    // Start
    public void ActivateStart()
    {
        start.SetActive(true);
    }

    public void DeActivateStart()
    {
        start.SetActive(false);
    }

    public bool GetStart()
    {
        return start.activeSelf;
    }


    // Paused
    public void ActivatePause()
    {
        paused.SetActive(true);
    }

    public void DeActivatePause()
    {
        paused.SetActive(false);
    }

    public bool GetPause()
    {
        return paused.activeSelf;
    }


    // Quit
    public void ActivateQuit()
    {
        quit.SetActive(true);
    }

    public void DeActivateQuit()
    {
        quit.SetActive(false);
    }

    public bool GetQuit()
    {
        return quit.activeSelf;
    }

    #endregion

    
    #region Scores

    // SoresDisplay
    public void ActivateScoresDisplay()
    {
        soresDisplay.SetActive(true);
    }
    
    public void DeActivateScoresDisplay()
    {
        soresDisplay.SetActive(false);
    }
    
    public bool GetScoresDisplay()
    {
        return soresDisplay.activeSelf;
    }
    
    
    // Chnage Scores
    public void ActivateChnageScores()
    {
        chnageScores.SetActive(true);
    }
    
    public void DeActivateChnageScores()
    {
        chnageScores.SetActive(false);
    }
    
    public bool GetChnageScores()
    {
        return chnageScores.activeSelf;
    }
    
    // Permanentt scores
    public void ActivatePermanenttScores()
    {
        permanenttScores.SetActive(true);
    }
    
    public void DeActivatePermanenttScores()
    {
        permanenttScores.SetActive(false);
    }
    
    public bool GetPermanenttScores()
    {
        return permanenttScores.activeSelf;
    }


    // In results scores
    public void ActivateScoresInResults()
    {
        scoresInResults.SetActive(true);
    }
    
    public void DeActivateScoresInResults()
    {
        scoresInResults.SetActive(false);
    }
    
    public bool GetScoresInResults()
    {
        return scoresInResults.activeSelf;
    }
    
    // In menu scores
    public void ActivateScoresInMenu()
    {
        scoresInMenu.SetActive(true);
    }
    
    public void DeActivateScoresInMenu()
    {
        scoresInMenu.SetActive(false);
    }
    
    public bool GetScoresInMenu()
    {
        return scoresInMenu.activeSelf;
    }
    
    
    // New high score
    public void ActivateNewHighScore()
    {
        newHighScore.SetActive(true);
    }
    
    public void DeActivateNewHighScore()
    {
        newHighScore.SetActive(false);
    }
    
    public bool GetNewHighScore()
    {
        return newHighScore.activeSelf;
    }
    
    #endregion
    

    #region Buttons

    // Back to menu button
    public void ActivateBackToMenuButton()
    {
        scoresBackToMenuButton.SetActive(true);
    }
    
    public void DeActivateBackToMenuButton()
    {
        scoresBackToMenuButton.SetActive(false);
    }
    
    public bool GetBackToMenuButton()
    {
        return scoresBackToMenuButton.activeSelf;
    }
    
    
    // Pause button
    public void ActivatePauseButton()
    {
        pauseButton.SetActive(true);
    }
    
    public void DeActivatePauseButton()
    {
        pauseButton.SetActive(false);
    }
    
    public bool GetPauseButton()
    {
        return pauseButton.activeSelf;
    }

    #endregion
    
    
    // Intro cadts
    #region Intro ccards
    
    // intro cards holder
    public void ActivateIntroCradsHolder()
    {
        introCradsHolder.SetActive(true);
    }

    public void DeActivateIntroCradsHolder()
    {
        introCradsHolder.SetActive(false);
    }

    public bool GetIntroCradsHolder()
    {
        return introCradsHolder.activeSelf;
    }
    
    
    // Intro cards
    public void ActivateIntroCrads(int index)
    {
        introCards[index].SetActive(true);
    }

    public void DeActivateIntroCrads(int index)
    {
        introCards[index].SetActive(false);
    }

    public bool GetIntroCrads(int index)
    {
        return introCards[index].activeSelf;
    }

    public int GetIntroCardsSize()
    {
        return introCards.Length;
    }
    
    
    // Intro cards Arrow left button
    public void ActivateIntroCardsLeftArrowButton()
    {
        introCardsLeftArrowButton.SetActive(true);
    }

    public void DeActivateIntroCardsLeftArrowButton()
    {
        introCardsLeftArrowButton.SetActive(false);
    }

    public bool GetIntroCardsLeftArrowButton()
    {
        return introCardsLeftArrowButton.activeSelf;
    }
    
    
    // Intro cards Arrow left button
    public void ActivateIntroCardsRightArrowButton()
    {
        introCardsRightArrowButton.SetActive(true);
    }

    public void DeActivateIntroCardsRightArrowButton()
    {
        introCardsRightArrowButton.SetActive(false);
    }

    public bool GetIntroCardsRightArrowButton()
    {
        return introCardsRightArrowButton.activeSelf;
    }
    
    
    // Intro cards Arrow left button
    public void ActivateIntroCardsStartButton()
    {
        introCardsStartButton.SetActive(true);
    }

    public void DeActivateIntroCardsStartButton()
    {
        introCardsStartButton.SetActive(false);
    }

    public bool GetIntroCardsStartButton()
    {
        return introCardsStartButton.activeSelf;
    }
    
    
    // Intro cards got it Button
    public void ActivateIntroCardsGotItButton()
    {
        introCardsGotItButton.SetActive(true);
    }

    public void DeActivateIntroCardsGotItButton()
    {
        introCardsGotItButton.SetActive(false);
    }

    public bool GetIntroCardsGotItButton()
    {
        return introCardsGotItButton.activeSelf;
    }
    
    
    // Intro cards Arrow left button
    public void ActivateIntroCardsLeftArrowButton()
    {
        introCardsLeftArrowButton.SetActive(true);
    }

    public void DeActivateIntroCardsLeftArrowButton()
    {
        introCardsLeftArrowButton.SetActive(false);
    }

    public bool GetIntroCardsLeftArrowButton()
    {
        return introCardsLeftArrowButton.activeSelf;
    }
    
    
    // Intro cards Arrow left button
    public void ActivateIntroCardsRightArrowButton()
    {
        introCardsRightArrowButton.SetActive(true);
    }

    public void DeActivateIntroCardsRightArrowButton()
    {
        introCardsRightArrowButton.SetActive(false);
    }

    public bool GetIntroCardsRightArrowButton()
    {
        return introCardsRightArrowButton.activeSelf;
    }
    
    
    // Intro cards Arrow left button
    public void ActivateIntroCardsStartButton()
    {
        introCardsStartButton.SetActive(true);
    }

    public void DeActivateIntroCardsStartButton()
    {
        introCardsStartButton.SetActive(false);
    }

    public bool GetIntroCardsStartButton()
    {
        return introCardsStartButton.activeSelf;
    }
    
    
    // Intro cards got it Button
    public void ActivateIntroCardsGotItButton()
    {
        introCardsGotItButton.SetActive(true);
    }

    public void DeActivateIntroCardsGotItButton()
    {
        introCardsGotItButton.SetActive(false);
    }

    public bool GetIntroCardsGotItButton()
    {
        return introCardsGotItButton.activeSelf;
    }
    
    #endregion


    // Text displays
    #region Text displays
    
    // anoucments - holder
    public void ActivateAnoucments()
    {
        anoucments.SetActive(true);
    }

    public void DeActivateAnoucments()
    {
        anoucments.SetActive(false);
    }

    public bool GetAnoucments()
    {
        return anoucments.activeSelf;
    }
    
    
    // anoucments - ready text
    public void ActivateReadyText()
    {
        readyText.SetActive(true);
    }

    public void DeActivateReadyText()
    {
        readyText.SetActive(false);
    }

    public bool GetReadyText()
    {
        return readyText.activeSelf;
    }


    // anoucments - Go text
    public void ActivateGoText()
    {
        goText.SetActive(true);
    }

    public void DeActivateGoText()
    {
        goText.SetActive(false);
    }

    public bool GetGoText()
    {
        return goText.activeSelf;
    }

    #endregion
}