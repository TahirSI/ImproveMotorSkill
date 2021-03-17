using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingText : MonoBehaviour
{
    private float startScale;
    private float maxScale;

    // Speeds
    private float setScaleSpeed;
    private float setFadeSpeed;

    // Distence
    private float startDistence;
    private float midDistence;

    // Scale fast and nopublic
    private bool fade;
    private bool scaleInFading;

    private bool scalingUp;

    // Update is called once per frame
    // ReSharper disable Unity.PerformanceAnalysis
    public void UpdateText()
    {
        // Scale Update
        transform.localScale += new Vector3(setScaleSpeed, setScaleSpeed, 0) * Time.deltaTime;
        
        
        // Fade uodate
        if (fade)
        {
            GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, setFadeSpeed) * Time.deltaTime;

            if (scaleInFading)
            {
                if (GetComponent<SpriteRenderer>().color.a >= 1)
                {
                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

                    fade = false;

                    scaleInFading = false;
                }
            }
            else
            {
                if (GetComponent<SpriteRenderer>().color.a <= 0)
                {
                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

                    fade = false;
                }
            }
        }


        bool checkStop = false;

        if (scalingUp)
        {
            if (GetCurrentScale().x >= maxScale)
            {
                checkStop = true;
            }
        }
        else
        {
            if (GetCurrentScale().x <= maxScale)
            {
                checkStop = true;
            }
        }


        // Scale reached fished
        if (checkStop)
        {
            // Set the scale back to start scale
            transform.localScale = new Vector3(startScale, startScale, 1);

            // Deactiv3te
            gameObject.SetActive(false);
        }

    }

    public void SetMinMaxScales(float min, float max)
    { 
        // Set teh star scale
        startScale = min;
        maxScale = max;


        if (min < max)
        {
            scalingUp = true;
        }

        var distance = max - min;

        if(distance < 0)
        {
            distance = -distance;
        }

        var partDis = distance / 4;
        
        
        if(scalingUp)
        {
            startDistence = partDis;
            midDistence = partDis * 3;
        }
        else
        {
            // reversed
            startDistence = partDis * 3;
            midDistence = partDis;
        }


        // Set the scale
        transform.localScale = new Vector3(min, min, 1);

        // Set fade
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }


    // Get the curent scale
    public Vector3 GetCurrentScale()
    {
        return transform.localScale;
    }

    public float GetStartScaleDis()
    {
        return startDistence;
    }

    public float GetMidScaleDis()
    {
        return midDistence;
    }


    // Seters
    public void SetScaleSpeed(float speed)
    {
        setScaleSpeed = speed;
    }

    public void SetFadeSpedd(float speed)
    {
        setFadeSpeed = speed;

        fade = true;

        if(setFadeSpeed > 0)
        {
            scaleInFading = true;
        }
        else if(setFadeSpeed < 0)
        {
            scaleInFading = false;
        }
    }

    public void ResetText()
    {
        fade = false;

        // Set the scale
        transform.localScale = new Vector3(startScale, startScale, 1);

        // Set fade
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

        gameObject.SetActive(false);
    }
}