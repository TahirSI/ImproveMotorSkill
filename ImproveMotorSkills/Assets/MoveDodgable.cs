 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDodgable : MonoBehaviour
{
    public float speed = 10;
    public float objectDestenc = -3;

    // Private
    private Vector3 begin_point = new Vector3(0, 0, 0);

    private void Start()
    {
        begin_point = transform.position;
    }

    // Update is called once per frame
    [System.Obsolete]
    public void UpdateObject()
    {
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;

        if (transform.position.x <= objectDestenc)
        {
            transform.position = begin_point;

            // Turn off the object
            DeactivateObject();
        }
    }

    [System.Obsolete]
    public void ActivateObject()
    {
        gameObject.active = true;
    }

    [System.Obsolete]
    public void DeactivateObject()
    {
        gameObject.active = false;
    }

    // Getters
    [System.Obsolete]
    public bool GetObjectActive()
    {
        return gameObject.active;
    }

    public Vector3 GetObjectPos()
    {
        return transform.position;
    }

    public Transform GetTransform()
    {
        return gameObject.transform;
    }
}
