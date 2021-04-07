 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDodgable : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    
    [SerializeField]
    private float objectDestenc = -3;
    
    [SerializeField]
    private Vector3 inputPosShift = Vector3.zero;

    
    private bool fadeOut;
    private float fadeOutSpeed = 3.5f;

    private Color beginColor;
    
    private SpriteRenderer spriteRen;

    
    private Vector3 beginPoint = new Vector3(0, 0, 0);

    public void SetUpStart()
    {
        beginPoint = transform.position;

        spriteRen = GetComponent<SpriteRenderer>();

        beginColor = spriteRen.material.color;
    }

    // Update is called once per frame
    public void UpdateObject()
    {
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;

        if (transform.position.x <= objectDestenc)
        {
            // Reset
            ResetMoveObject();
        }

        // Fade out object
        if (fadeOut)
        {
            var col = spriteRen.material.color;
            var fadeAmount = col.a - (fadeOutSpeed * Time.deltaTime);

            col = new Color(col.r, col.g, col.b, fadeAmount);

            spriteRen.material.color = col;
            
            // If fished
            if ( spriteRen.material.color.a <= 0)
            {
                // Reset fade
                ResetFadedObject();
            }
        }
    }

    public void ActiaveFadeOutObject()
    {
        fadeOut = true;
    }
    

    // Activation
    public void ActivateObject()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

    
    // Setters
    public void SetMoveSpeed(float setSpeed)
    {
        speed = setSpeed;
    }
    
    
    // Getters
    public bool GetObjectActive()
    {
        return gameObject.activeSelf;
    }

    public bool GetFadeding()
    {
        return fadeOut;
    }
    

    // values 
    public Vector3 GetObjectPos()
    {
        return transform.position;
    }

    public Transform GetTransform()
    {
        return gameObject.transform;
    }

    public Vector3 GetInputPosShift()
    {
        return inputPosShift;
    }
    
    
    // Reste object
    public void ResetMoveObject()
    {
        transform.position = beginPoint;

        // Turn off the object
        DeactivateObject();
    }
    
    // Reset fadeing
    public void ResetFadedObject()
    {
        // Rest color
        spriteRen.material.color = beginColor;

        fadeOut = false;
    }
}
