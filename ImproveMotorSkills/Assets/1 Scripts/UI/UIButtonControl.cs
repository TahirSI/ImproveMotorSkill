using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonControl : MonoBehaviour
{
    private UIControler uiControler;
    private MainUpdate mainUpdate;

    // Start is called before the first frame update
    private void Start()
    {
        uiControler = GetComponent<UIControler>();
        mainUpdate = FindObjectOfType<MainUpdate>();
    }

    // Start button
    public void StartButton()
    {
        mainUpdate.StartPlaying();
    }

    // Scores
    public void SwitchLookAtScoresMenuButton()
    {
        // Start menu
        if (!uiControler.GetScoresDisplay())
        {
            // Start - OFF
            uiControler.DeActivateStart();
            
            // Scores display - ON
            uiControler.ActivateScoresDisplay();
            
            mainUpdate.DisplayScoresMenu();
        }
        
        // Scores display
        else
        {
            // If looing at permant scores
            if (uiControler.GetPermanenttScores())
            {
                uiControler.DeActivatePermanenttScores();
                
                uiControler.ActivateChnageScores();
            }
            
            // Start - ON
            uiControler.ActivateStart();
            
            // Scores display - OFF
            uiControler.DeActivateScoresDisplay();
        }
    }

    public void MenuButton()
    {
        mainUpdate.Menu();
    }

    // Sent results
    public void SwitchResultDisplaysButton() 
    {
        mainUpdate.DisplayNewHighScore();
    }


    // Play again
    public void PlayAgainButton()
    {
        mainUpdate.PlayAgian();
    }

    // Resume game
    public void PauseResumeGameButton()
    {
        mainUpdate.PauseResume();
    }

    // Quit game
    public void QuitGameButton()
    {
        mainUpdate.QuitGame();
    }
}
