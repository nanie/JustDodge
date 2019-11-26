using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataManager
{
    public static void SaveData(ScoreBoard scoreBoard)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.jdg";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataSave dataSave = new DataSave(scoreBoard);

        binaryFormatter.Serialize(stream, dataSave);

        stream.Close();
    }

    public static DataSave LoadData(ScoreBoard scoreBoard)
    {
        string path = Application.persistentDataPath + "/save.jdg";

        if (!File.Exists(path))
        {
            DataManager.SaveData(scoreBoard);
        }
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        DataSave dataSave = binaryFormatter.Deserialize(stream) as DataSave;

        stream.Close();

        return dataSave;

    }
}
