using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHiScoreBlinking : MonoBehaviour
{
    public GameObject newHighScore;
    
    public Timer timer;

    // Update is called once per frame
    public void UpdateNewHighScore()
    {
        // Upade timer
        timer.UpdateTimer();

        if (timer.TimerReachedEnd())
        {
            // Flip the active states
            newHighScore.SetActive(!newHighScore.activeSelf);
            
            // Reset timer
            timer.ResetTimer();
            
            // Start timer
            timer.StartTimer();
        }
    }

    public void ResetNewHighScore()
    {
        // Reset timer
        timer.ResetTimer();
        
        // New score object - ON
        newHighScore.SetActive(true);
        
        gameObject.SetActive(false);
    }

    
    // Getters
    
    // Actiave staes
    public bool GetNewHighScoreActiveState()
    {
        return newHighScore.activeSelf;
    }
    
    // Get the timer
    public Timer GetTimer()
    {
        return timer;
    }
}
