using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataControl : MonoBehaviour
{
    public GameData gameData;

    #region Storring
    public void StorePermanentReults(int index, float result)
    {
        gameData.permanentStoredResults[index] = result;
    }

    public void StoreChangeableReults(int index, float result)
    {
        gameData.changeableStoredResults[index] = result;
    }
    #endregion


    #region Need to practice
    public void SetNeedToPractice(bool state)
    {
        gameData.needToPractice = state;
    }

    public bool GetNeedToPractice()
    {
        return gameData.needToPractice;
    }
    #endregion


    #region Collected mainresults
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
