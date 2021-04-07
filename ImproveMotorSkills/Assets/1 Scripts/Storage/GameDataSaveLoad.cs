using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class GameDataSaveLoad : MonoBehaviour
{
    GameDataControl gameDataControll;

    // Start is called before the first frame update
    void Awake()
    {
        gameDataControll = GetComponent<GameDataControl>();
        LoadData();
    }

    private string filePath => Application.persistentDataPath + "/MotorSkillsGemData.dat";

    public void SaveData()
    {
        FileStream file = new FileStream(filePath, FileMode.OpenOrCreate);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, gameDataControll.gameData);
        }
        catch (SerializationException exp)
        {
            Debug.Log("There was a problum with trying to Serializing the data: " + exp.Data);
        }
        finally
        {
            file.Close();
        }
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            FileStream file = new FileStream(filePath, FileMode.Open);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                gameDataControll.gameData = formatter.Deserialize(file) as GameData;

            }
            catch (SerializationException exp)
            {
                Debug.Log("Erro with with trying to de-serializing the data: " + exp.Data);
            }
            finally
            {
                file.Close();
            }
        }
    }

    public void Delete()
    {
        try
        {
            File.Delete(filePath);
        }
        catch (SerializationException exp)
        {
            Debug.Log("Erro File cant be deleted: " + exp.Data);
        }
    }
}
