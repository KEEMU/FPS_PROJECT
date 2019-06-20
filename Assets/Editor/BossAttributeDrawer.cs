using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BossAttribute))]
public class BossAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var name = property.FindPropertyRelative("name");
        var hp = property.FindPropertyRelative("HP");
        var speed = property.FindPropertyRelative("speed");
        var phase = property.FindPropertyRelative("phase");

        EditorGUI.LabelField(position, "Name");
    }
}