using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataControl : MonoBehaviour
{
    public GameData gameData;

    #region Storring / Getting
    
    // Permanent data 
    public void StorePermanentReults(int index, float result)
    {
        gameData.permanentStoredResults[index] = result;
    }
    
    // Avrage
    public void StorePermanentAvrage(float result)
    {
        gameData.permanentAvrageResult = result;
    }
    
    // Getters
    public float GetPermanentReults(int index)
    {
        return gameData.permanentStoredResults[index];
    }
    
    public float GetPermanentAvrage()
    {
        return gameData.permanentAvrageResult;
    }
    
    
    // Chgange data
    public void StoreChangeableReults(int index, float result)
    {
        gameData.changeableStoredResults[index] = result;
    }

    // Avrage
    public void StoreChangeableAvrage(float result)
    {
        gameData.changeableAvrageResult = result;
    }
    
    
    // Getters
    public float GetChangeableReults(int index)
    {
        return gameData.changeableStoredResults[index];
    }

    public float GetChangeableAvrage()
    {
        return gameData.changeableAvrageResult;
    }
    
    #endregion


    #region practicing
    
    // Practice dGame
    public void SetPracticedGame(bool state)
    {
        gameData.practicedGame = state;
    }

    public bool GetPracticedGame()
    {
        return gameData.practicedGame;
    }
    #endregion


    #region played first time

    public void SetPlayedFistTime(bool set)
    {
        gameData.playedFistTime = set;
    }
    
    public bool GetPlayedFistTime()
    {
        return gameData.playedFistTime;
    }

    #endregion
    
    
    #region Collected main scores
    public void SetPermanentDataStorage(bool state)
    {
        gameData.gotPermanentStorage = state;
    }

    public bool GetPermanentDataStored()
    {
        return gameData.gotPermanentStorage;
    }
    
    #endregion
}
