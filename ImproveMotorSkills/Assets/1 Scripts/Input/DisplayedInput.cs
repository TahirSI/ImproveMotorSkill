using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayedInput : MonoBehaviour
{
    public Camera cam;

    private Vector3 posShift = Vector3.zero;

    public Settings settings;

    // Move
    public void Move(Vector3 target)
    {
        Vector3 screenPos = cam.WorldToScreenPoint(target);

        Vector3 setPos = new Vector3(screenPos.x + posShift.x, screenPos.y + posShift.y, screenPos.z + posShift.z);

        transform.position = setPos;
    }
    
    // Set the pos where the shift placment
    public void SetPosShift(Vector3 setShift)
    {
        posShift = setShift;
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
    public void SetImage(int index)
    {
        GetComponent<Image>().sprite = settings.imputImages[index];
    }

    public Vector3 GetPos()
    {
        return transform.position;
    }
}