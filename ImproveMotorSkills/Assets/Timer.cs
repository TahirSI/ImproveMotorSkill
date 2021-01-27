using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerToStoAt = 3;
    float time = 0;
    public Text timeText;

    // Bools
    bool timer_on = true;
    bool reset_timer = false;
    bool timerReachedEnd = false;

    // Update is called once per frame
    public void UpdateTimer()
    {
        // Timer ON
        if (timer_on)
        {
            time += Time.deltaTime;
            DisplayTime(time);

            if (time >= timerToStoAt)
            {
                time = timerToStoAt;
                DisplayTime(time);

                timer_on = false;

                // End of timer
                timerReachedEnd = true;
            }
        }

        // Reset timer
        if (reset_timer)
        {
            time = 0;
            DisplayTime(time);

            timerReachedEnd = false;     // Reached time
            reset_timer = false;            // Reset timer

            timer_on = false;
        }
    }

    // Display text
    void DisplayTime(float _time)
    {
        timeText.text = time.ToString("F6");
    }

    // Start timer 
    public void StartTimer()
    {
        timer_on = true;
    }

    // Restart 
    public void ResetTimer()
    {
        reset_timer = true;
    }

    // Get timer amount 
    public float GetTimerToStopAmount()
    {
        return timerToStoAt;
    }

    // Get the reached time
    public bool TimerReachedEnd()
    {
        return timerReachedEnd;
    }

    // Get the currnt time
    public float GetCurrentTime()
    {
        return time;
    }
}