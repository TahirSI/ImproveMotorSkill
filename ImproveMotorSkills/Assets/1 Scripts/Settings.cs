using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Main settings

    // Bools

    [HideInInspector]
    public bool stopMovingGround = false;

    // anaoucment text
    public Vector2 readytextScalMinMax = Vector2.zero;
    public Vector2 gotextScalMinMax = Vector2.zero;

    public Vector3 readyTextScaleSpeed = Vector3.zero;
    public Vector3 goTextScaleSpeed = Vector3.zero;

    public Vector2 readyTextFadeSpeed = Vector3.zero;
    public Vector2 goTextFadeSpeed = Vector3.zero;

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
