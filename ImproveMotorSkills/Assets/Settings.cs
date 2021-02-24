using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Main settings
    public float groundSpeed = 20;
    public float dodgableObjectsSpeed = 20;


    public GameObject dodgableObjectPernet;
    public float dogdgbleInputEndPoint = -26;

    public float dodgeTime = 15;

    // Inpiut stuff
    public KeyCode [] kyes;

    public int[] inputValues;

    public Sprite[] imputImages;
}
