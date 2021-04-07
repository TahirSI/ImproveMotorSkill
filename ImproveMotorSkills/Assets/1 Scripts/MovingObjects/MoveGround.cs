using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField] 
    private float negativeXPos;
    
    [SerializeField]
    private float speed = 10;
    
    [SerializeField]
    private Transform transportpoint;

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

            if (transform.position.x <= negativeXPos)
            {
                move = new Vector3(transportpoint.position.x + 22.109f, transportpoint.position.y, 0);

                transform.position = move;
            }
        }
    }
}
