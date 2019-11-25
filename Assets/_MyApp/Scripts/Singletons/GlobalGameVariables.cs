using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameVariables : MonoBehaviour
{
    private static GlobalGameVariables instance;
    public ScriptableGameVariables variables;

    public static GlobalGameVariables Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameVariables");
                instance = go.AddComponent<GlobalGameVariables>();
                instance.StartInstance();
            }
            return instance;
        }
    }

    private void StartInstance()
    {
        var allObjects = Resources.LoadAll<ScriptableGameVariables>("");
        foreach (var item in allObjects)
        {
            if (item.inUse)
            {
                variables = item;
                break;
            }
        }
    }
}
