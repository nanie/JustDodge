using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(ScriptableGameVariables))]
[CanEditMultipleObjects]
public class EditorGameVariables : Editor
{

    void OnEnable()
    {

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        base.OnInspectorGUI();
        ScriptableGameVariables myScript = (ScriptableGameVariables)target;
        if (!myScript.inUse)
            EditorGUILayout.HelpBox("This object is not in use", MessageType.Warning);
        else
            EditorGUILayout.HelpBox("This is the variables in use", MessageType.Info);

        var allObjects = Resources.LoadAll<ScriptableGameVariables>("");

        if (!allObjects.Any(q => q.inUse))
        {
            EditorGUILayout.HelpBox("There is no variables in use", MessageType.Error);
        }

        if (allObjects.Count(q => q.inUse) > 1)
        {
            EditorGUILayout.HelpBox("There is more than one variables set as in use", MessageType.Error);
            
        }
        serializedObject.ApplyModifiedProperties();
    }
}
