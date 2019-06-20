using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Enemy))]
[CanEditMultipleObjects]
public class EnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("enemyAttribute"), true);
        EditorGUILayout.HelpBox("Set separate enemy file for each.", MessageType.Info);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("wanderingState"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("attackingState"), true);

        serializedObject.ApplyModifiedProperties();
    }
}