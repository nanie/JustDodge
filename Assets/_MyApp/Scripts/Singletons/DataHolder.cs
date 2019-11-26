using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    private static DataHolder instance;
    public int currentScore;
    public string currentPlayerName;

    //If there isnt a DataHolder, create one
    public static DataHolder Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("DataHolder");
                instance = go.AddComponent<DataHolder>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }
}
