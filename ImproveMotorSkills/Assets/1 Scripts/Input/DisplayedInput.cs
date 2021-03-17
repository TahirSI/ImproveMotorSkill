using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayedInput : MonoBehaviour
{
    private Vector3 shiftPosAdd = Vector3.zero;
    
    
    public SpriteRenderer inputText;
    
    public Settings settings;

    // Move
    // ReSharper disable Unity.PerformanceAnalysis
    public void Move(Vector3 pos)
    {
        transform.position = pos + shiftPosAdd;
    }
    
    // Set the pos where the shift placment
    public void SetPosShift(Vector3 setShift)
    {
        shiftPosAdd = setShift;
    }

    // Activate object
    public void ActivateObject()
    {
        gameObject.SetActive(true);
    }

    // Deactivate object
    public void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

    // Get gameObject
    public bool GetAcativeObject()
    {
        return gameObject.activeSelf;
    }


    // setters
    // ReSharper disable Unity.PerformanceAnalysis
    public void SetImage(int index)
    {
        inputText.sprite = settings.imputImages[index];
    }

    public Vector3 GetPos()
    {
        return transform.position;
    }
}
