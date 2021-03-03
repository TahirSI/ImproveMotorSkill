 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDodgable : MonoBehaviour
{
    [SerializeField]
    public float speed = 10;

    public float objectDestenc = -3;

    // Private
    private Vector3 begin_point = new Vector3(0, 0, 0);

    private void Start()
    {
        begin_point = transform.position;
    }

    // Update is called once per frame
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

    // Activation
    public void ActivateObject()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateObject()
    {
        gameObject.SetActive(false);
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
}
