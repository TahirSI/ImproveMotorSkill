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
    [System.Obsolete]
    public void ActivateObject()
    {
        gameObject.active = true;
    }

    // Deactivate object
    [System.Obsolete]
    public void DeactivateObject()
    {
        gameObject.active = false;
    }

    [System.Obsolete]
    public bool GetAcativeObject()
    {
        return gameObject.active;
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
