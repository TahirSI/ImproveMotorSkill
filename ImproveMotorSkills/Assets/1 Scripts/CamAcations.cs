using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CamAcations : MonoBehaviour
{
    [SerializeField]
    private  float zoomedOutCamPoint = 0.4f;
    
    [SerializeField]
    private  float zoomedInCamPoint = 0.4f;
    
    [SerializeField]
    private  float aniInSpeed = 8;

    [SerializeField]
    private  float aniOutSpeed = 2;
    
    private float direction = 1;
    
    private bool animate;
    
    // Update is called once per frame
    public void UpdateCam()
    {
        if (animate)
        {
            // Forword
            if (direction >= 1)
            {
                transform.position += new Vector3(0, 0, aniInSpeed) * Time.deltaTime;

                // Reached point
                if (transform.position.z >= zoomedInCamPoint)
                {
                    transform.position = new Vector3(
                        transform.position.x,
                        transform.position.y,
                        zoomedInCamPoint);;

                    animate = false;
                }
            }
            
            // Backwords
            else if (direction <= -1)
            {
                transform.position -= new Vector3(0, 0, aniOutSpeed) * Time.deltaTime;

                // Reached point
                if (transform.position.z <= zoomedOutCamPoint)
                {
                    // Set the point
                    transform.position = new Vector3(
                        transform.position.x,
                        transform.position.y,
                        zoomedOutCamPoint);

                    animate = false;
                }
            }
        }
    }

    public void AnimateIn()
    {
        animate = true;
        
        direction = 1;
    }
    
    
    public void AnimateOut()
    {
        animate = true;
        
        direction = -1;
    }

    public bool GetAnimating()
    {
        return animate;
    }
}
