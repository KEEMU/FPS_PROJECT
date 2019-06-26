using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomPropertyDrawer(typeof(BossAttribute))]
public class BossAttributeDrawer : PropertyDrawer
{
    bool fold = true;
    ReorderableList list;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var name = property.FindPropertyRelative("name");
        var hp = property.FindPropertyRelative("HP");
        var speed = property.FindPropertyRelative("speed");
        var phase = property.FindPropertyRelative("phase");
        var skillInterval = property.FindPropertyRelative("skillInterval");
        var skills = property.FindPropertyRelative("skills");
        fold = EditorGUILayout.Foldout(fold, "Boss Data");
        if (fold)
        {
            EditorGUILayout.HelpBox("Please refer to excel sheet. ", MessageType.None);
            var ori = EditorStyles.label.fontStyle;
            EditorStyles.label.fontStyle = FontStyle.Bold;
            EditorGUILayout.PropertyField(name);
            EditorGUILayout.PropertyField(hp);
            if (hp.intValue < 100)
            {
                if (hp.intValue < 0)
                {
                    EditorGUILayout.HelpBox("HP must be over 0.", MessageType.Error);
                }
                else
                {
                    EditorGUILayout.HelpBox("It is sugguested that boss HP not be under 100.", MessageType.Warning);
                }
            }
            EditorGUILayout.PropertyField(speed);
            if (speed.floatValue < 0)
            {
                EditorGUILayout.HelpBox("Speed must be over 0.", MessageType.Error);
            }
            EditorGUILayout.PropertyField(phase);
            EditorGUILayout.PropertyField(skillInterval);
            EditorGUILayout.HelpBox("Note that currently one skill only supports single executing method.", MessageType.Warning);
            Initialize(skills);


            list.DoLayoutList();

            CheckPhaseViabililty(phase.intValue);

            EditorStyles.label.fontStyle = ori;
        }
    }

    void Initialize(SerializedProperty property)
    {
        if (list != null) return;
        list = new ReorderableList(property.serializedObject, property);

        var skillEvent = property.FindPropertyRelative("skillEvent");
        var cooldown = property.FindPropertyRelative("cooldown");
        var chance = property.FindPropertyRelative("chance");
        var triggerDistance = property.FindPropertyRelative("triggerDistance");
        var triggerPhase = property.FindPropertyRelative("triggerPhase");

        list.elementHeightCallback = (int index) =>
        {
            return 165;
        };
        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = list.serializedProperty.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, rect.height), element.FindPropertyRelative("skillEvent"));
            Rect cooldownLabel = new Rect(rect.x, rect.y + 85, 200, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(cooldownLabel, "Cooldown");
            Rect cooldownField = new Rect(cooldownLabel) { x = rect.width, width = 30 };
            EditorGUI.PropertyField(cooldownField, element.FindPropertyRelative("cooldown"), GUIContent.none);
            EditorGUI.LabelField(new Rect(cooldownLabel) { y = cooldownLabel.y + EditorGUIUtility.singleLineHeight + 3 }, "Chance");
            EditorGUI.PropertyField(new Rect(cooldownField) { y = cooldownField.y + EditorGUIUtility.singleLineHeight + 3 }, element.FindPropertyRelative("chance"), GUIContent.none);
            EditorGUI.LabelField(new Rect(cooldownLabel) { y = cooldownLabel.y + EditorGUIUtility.singleLineHeight * 2 + 6 }, "Trigger Distance");
            EditorGUI.PropertyField(new Rect(cooldownField) { y = cooldownField.y + EditorGUIUtility.singleLineHeight * 2 + 6 }, element.FindPropertyRelative("triggerDistance"), GUIContent.none);
            EditorGUI.LabelField(new Rect(cooldownLabel) { y = cooldownLabel.y + EditorGUIUtility.singleLineHeight * 3 + 9 }, "Trigger Phase");
            EditorGUI.PropertyField(new Rect(cooldownField) { x = cooldownField.x - 50, y = cooldownField.y + EditorGUIUtility.singleLineHeight * 3 + 9, width = 80 }, element.FindPropertyRelative("triggerPhase"), GUIContent.none);

        };
        list.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Skill Set");
        };
        list.onRemoveCallback = (ReorderableList l) =>
        {
            if (EditorUtility.DisplayDialog("Confirm", "Are you sure to delete this skill?", "Yes", "No"))
            {
                ReorderableList.defaultBehaviours.DoRemoveButton(l);
            }
        };
    }

    void CheckPhaseViabililty(int phaseInt)
    {
        for (int i = 0; i < list.serializedProperty.arraySize; i++)
        {
            int v = list.serializedProperty.GetArrayElementAtIndex(i).FindPropertyRelative("triggerPhase").intValue;
            if (v >= Mathf.Pow(2, phaseInt) || (v == -1 && phaseInt != 3))
            {
                EditorGUILayout.HelpBox("These is at least one skill phase inappropriate!", MessageType.Error);
                break;
            }
        }
    }
}