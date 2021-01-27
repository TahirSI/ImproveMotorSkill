using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObsticles : MonoBehaviour
{
    public Transform beginingPos;
    public float speed = 10;

    private Vector3 begin_point = new Vector3(0, 0, 0);

    private void Start()
    {
        begin_point = this.transform.position;
    }

    // Update is called once per frame
    public void UpdateObject()
    {
        Vector3 move = new Vector3(speed, 0, 0);

        this.transform.position -= move * Time.deltaTime;

        if (transform.position.x <= -17)
        {
            this.transform.position = begin_point;
        }
    }

    [System.Obsolete]
    public void ActivateObject()
    {
        this.gameObject.active = true;
    }

    [System.Obsolete]
    public bool GetObjectActive()
    {
        return this.gameObject.active;
    }
}
