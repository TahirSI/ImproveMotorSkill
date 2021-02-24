using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerToStopAt = 3;
    float time = 0;

    // Bools
    bool timer_on = false;
    bool timerReachedEnd = false;

    // Update is called once per frame
    public void UpdateTimer()
    {
        // Timer ON
        if (timer_on)
        {
            time += Time.deltaTime;

            if (time >= timerToStopAt)
            {
                time = timerToStopAt;

                timer_on = false;

                // End of timer
                timerReachedEnd = true;
            }
        }
    }

    // Start timer 
    public void StartTimer()
    {
        timer_on = true;
    }

    // Restart 
    public void ResetTimer()
    {
        time = 0;

        timerReachedEnd = false;     // Reached time

        timer_on = false;
    }

    // Get timer amount 
    public float GetTimerToStopAmount()
    {
        return timerToStopAt;
    }

    // Get timer still on
    public bool GetTimerStillOn()
    {
        return timer_on;
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