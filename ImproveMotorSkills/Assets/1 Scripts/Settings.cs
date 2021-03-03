using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Main settings

    // Bools
    public bool stopMovingGround = false;


    public float groundMoveSpeed = 20;
    public float dodgableObjectsSpeed = 20;

    public float objectsFastSpeed = 20;

    public float playerJumpMulti = 18;

    public float gotHitrotSpeed = 25;

    public Transform dodgableObjectPernet;

    public float dodgeTime = 15;

    // Inpiut stuff
    public KeyCode [] kyes;

    public int[] inputValues;

    public Sprite[] imputImages;
}
