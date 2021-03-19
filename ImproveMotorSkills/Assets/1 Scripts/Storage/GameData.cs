using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class GameData
{
    // results
    public float[] permanentStoredResults = new float [10];
    public float[] changeableStoredResults = new float [10];

    public float permanentAvrageResult;
    public float changeableAvrageResult;
    
    // Long time checks
    public bool practicedGame;
    public bool gotPermanentStorage;

    public bool playedFistTime;
}
