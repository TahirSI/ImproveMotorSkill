using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public float speed = 10;

    public Transform transportpoint;

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3 ( speed, 0, 0);

        this.transform.position -= move * Time.deltaTime;

        if(transform.position.x <= -16)
        {
            move = new Vector3(transportpoint.position.x + 11, 0, 0);

            this.transform.position = move;
        }
    }
}
