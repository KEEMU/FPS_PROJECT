using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyData))]
[CanEditMultipleObjects]
public class EnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {

        serializedObject.Update();
        base.OnInspectorGUI();
        serializedObject.ApplyModifiedProperties();
    }
}