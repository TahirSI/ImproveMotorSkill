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
    
    
    private Vector3 begin_point = new Vector3(0, 0, 0);

    public void SetBegingPos()
    {
        begin_point = transform.position;
    }

    // Update is called once per frame
    public void UpdateObject()
    {
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;

        if (transform.position.x <= objectDestenc)
        {
            // Reset
            ResetObject();
        }
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
    public void SetSpeed(float setSpeed)
    {
        speed = setSpeed;
    }
    
    
    // Getters
    public bool GetObjectActive()
    {
        return gameObject.activeSelf;
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
    public void ResetObject()
    {
        transform.position = begin_point;

        // Turn off the object
        DeactivateObject();
    }
}
