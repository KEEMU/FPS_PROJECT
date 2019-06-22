using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EnemyAttribute))]
public class EnemyAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorStyles.label.fontStyle = FontStyle.Normal;
        var name = property.FindPropertyRelative("name");
        var genre = property.FindPropertyRelative("genre");
        var hp = property.FindPropertyRelative("HP");
        var speed = property.FindPropertyRelative("speed");
        var detectRange = property.FindPropertyRelative("detectRange");
        var meleeRange = property.FindPropertyRelative("meleeRange");
        var rangedRange = property.FindPropertyRelative("rangedRange");

        EditorGUILayout.PropertyField(name);
        EditorGUILayout.PropertyField(genre);
        EditorGUILayout.PropertyField(hp);
        if (hp.intValue < 0)
        {
            EditorGUILayout.HelpBox("HP must be over 0.", MessageType.Error);
        }
        EditorGUILayout.PropertyField(speed);
        if (speed.floatValue < 0)
        {
            EditorGUILayout.HelpBox("Speed must be over 0.", MessageType.Error);
        }
        EditorGUILayout.PropertyField(detectRange);
        meleeRange.floatValue = EditorGUILayout.Slider("Melee Attack Range", meleeRange.floatValue, 1f, 2f);
        if (genre.intValue == (int)EnemyGenre.Ranged)
        {
            EditorGUILayout.HelpBox("Ranged enemy uses melee attack animation, being close to the player.", MessageType.None);
            rangedRange.floatValue = EditorGUILayout.Slider("Ranged Attack Range", rangedRange.floatValue, 5f, 10f);
        }
    }
}