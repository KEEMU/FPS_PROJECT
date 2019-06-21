using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EnemyData))]
[CanEditMultipleObjects]
public class EnemyEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        property.serializedObject.Update();

        var attribute = property.FindPropertyRelative("attribute");
        EditorGUILayout.PropertyField(attribute);

        property.serializedObject.ApplyModifiedProperties();
    }
}