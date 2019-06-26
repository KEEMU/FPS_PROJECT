using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EnemyAttribute))]
public class EnemyAttributeDrawer : PropertyDrawer
{
    GUILayoutOption range = GUILayout.Width(200);

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
        var patrolStyle = property.FindPropertyRelative("patrolStyle");
        var patrolRange = property.FindPropertyRelative("patrolRange");
        var chaseRange = property.FindPropertyRelative("chaseRange");

        EditorGUILayout.PropertyField(name);
        if (name.stringValue.Equals(""))
        {
            EditorGUILayout.HelpBox("Enemy needs a name!", MessageType.Error);
        }

        /* 项目“Assembly-CSharp-Editor”的未合并的更改
        在此之前:
                EditorGUILayout.flot
                if (hp.intValue < 0)
                {
                    EditorGUILayout.HelpBox("HP must be over 0.", MessageType.Error);
                }
                EditorGUILayout.PropertyField(speed);
        在此之后:
                EditorGUILayout.PropertyField(speed);
        */     EditorGUILayout.PropertyField(genre);
        meleeRange.floatValue = EditorGUILayout.Slider("Melee Attack Range", meleeRange.floatValue, 1f, 2f);
        if (genre.intValue == (int)EnemyGenre.Ranged)
        {
            EditorGUILayout.HelpBox("Ranged enemy uses melee attack animation, being close to the player.", MessageType.None);
            rangedRange.floatValue = EditorGUILayout.Slider("Ranged Attack Range", rangedRange.floatValue, 5f, 10f);
        }
        EditorGUILayout.PropertyField(patrolStyle);
        if (patrolStyle.intValue != (int)PatrolStyle.Still)
        {
            EditorGUILayout.PropertyField(patrolRange, range);
        }
        EditorGUILayout.PropertyField(chaseRange, range);
    }
}