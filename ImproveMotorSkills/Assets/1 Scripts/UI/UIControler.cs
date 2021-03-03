using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{
    // Start
    public GameObject start;

    // Pause
    public GameObject paused;

    // Quit
    public GameObject quit;

    // Diplaying text - anoucment
    public GameObject anoucments;
    public GameObject readyText;
    public GameObject goText;

    // Intro crds - practice attempt
    public GameObject introCradsHolder;
    public GameObject[] introCards;

    // Scores
    public GameObject scoreDisplay;
    public GameObject justGotScores;
    public GameObject sendtScores;

    public GameObject sentResultsButton;
    public GameObject backResultsButton;

    public Text[] justGotScoresTexts;
    public Text[] sentScoresTexts;

    // Set Scores
    public void SetJustGotScoreText(int index, float amount)
    {
        string toSet = "";

        if (amount <= 0)
        {
            toSet = "Missed";
        }
        else
        {
            toSet = amount.ToString();
        }

        justGotScoresTexts[index].text = toSet;
    }

    public void SetSentScoreData(int index, float amount)
    {
        string toSet = "";

        if (amount <= 0)
        {
            toSet = "Missed";
        }
        else
        {
            toSet = amount.ToString();
        }

        sentScoresTexts[index].text = toSet;
    }


    // Actions

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


    // Score display
    public void ActivateScoreDisplay()
    {
        scoreDisplay.SetActive(true);
    }

    public void DeActivateScoreDisplay()
    {
        scoreDisplay.SetActive(false);
    }

    public bool GetScoreDisplay()
    {
        return scoreDisplay.activeSelf;
    }


    // Just got scores
    public void ActivateJustGotScores()
    {
        justGotScores.SetActive(true);
    }

    public void DeActivateJustGotScores()
    {
        justGotScores.SetActive(false);
    }

    public bool GetJustGotScores()
    {
        return justGotScores.activeSelf;
    }


    // Set scores
    public void ActivateSendtScores()
    {
        sendtScores.SetActive(true);
    }

    public void DeActivateSendtScores()
    {
        sendtScores.SetActive(false);
    }

    public bool GetSendtScores()
    {
        return sendtScores.activeSelf;
    }


    // Sent results button
    public void ActivateSentResultsButton()
    {
        sentResultsButton.SetActive(true);
    }

    public void DeActivateSentResultsButton()
    {
        sentResultsButton.SetActive(false);
    }

    public bool GetSentResultsButton()
    {
        return sentResultsButton.activeSelf;
    }


    // BAck to results button
    public void ActivateBackResultsButton()
    {
        sentResultsButton.SetActive(true);
    }

    public void DeActivateBackResultsButton()
    {
        sentResultsButton.SetActive(false);
    }

    public bool GetBackResultsButton()
    {
        return sentResultsButton.activeSelf;
    }


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


    // Intro cadts

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
}