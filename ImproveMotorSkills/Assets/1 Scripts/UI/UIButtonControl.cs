using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonControl : MonoBehaviour
{
    private UIControler uiControler;
    private MainUpdate mainUpdate;

    // Start is called before the first frame update
    void Start()
    {
        uiControler = GetComponent<UIControler>();
        mainUpdate = FindObjectOfType<MainUpdate>();
    }

    // Start button
    public void StartButton()
    {
        mainUpdate.StartPlaying();
    }

    // Sent results
    public void SwitchResultDisplaysButton()
    {
        if(uiControler.GetJustGotScores())
        {
            // Turn OFF the just got resulst 
            uiControler.DeActivateSentResultsButton();
            uiControler.DeActivateJustGotScores();

            // Turn ON Sent results
            uiControler.ActivateBackResultsButton();
            uiControler.ActivateSendtScores();
        }
        else if(uiControler.GetSendtScores())
        {
            // Turn ON the just got resulst 
            uiControler.ActivateSentResultsButton();
            uiControler.ActivateJustGotScores();

            // Turn OFF Sent results
            uiControler.DeActivateBackResultsButton();
            uiControler.DeActivateSendtScores();
        }
    }


    // Play again
    public void PlayAgainButton()
    {
        mainUpdate.PlayAgian();
    }

    // Resume game
    public void ResumeGameButton()
    {
        mainUpdate.PauseResume();
    }

    // Quit game
    public void QuitGameButton()
    {
        mainUpdate.QuitGame();
    }
}
