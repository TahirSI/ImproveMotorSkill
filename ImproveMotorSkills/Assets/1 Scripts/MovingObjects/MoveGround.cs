using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField]
    public float speed = 10;

    public Transform transportpoint;

    private Settings settings;

    private void Awake()
    {
        settings = FindObjectOfType<Settings>();

        speed = settings.groundMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!settings.stopMovingGround)
        {
            Vector3 move = new Vector3(speed, 0, 0);

            this.transform.position -= move * Time.deltaTime;

            if (transform.position.x <= -13)
            {
                move = new Vector3(transportpoint.position.x + 11, 0, 0);

                transform.position = move;
            }
        }
    }
}
