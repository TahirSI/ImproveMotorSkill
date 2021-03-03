using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // results
    public float[] permanentStoredResults = new float [10];
    public float[] changeableStoredResults = new float [10];

    // Long time checks
    public bool needToPractice = false;
    public bool gotPermanentStorage = false;
}
