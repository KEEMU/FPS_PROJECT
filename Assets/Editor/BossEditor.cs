using UnityEditor;
using UnityEngine;
using UnityEditorInternal;

[CustomEditor(typeof(BossData))]
[CanEditMultipleObjects]
public class BossEditor : Editor
{
    BossData bossData;

    BossAttribute robot;
    ReorderableList robotSkills;
    bool robotFold = true;

    void OnEnable()
    {
        bossData = (BossData)target;
        robot = bossData.bossAttribute;
        robotSkills = new ReorderableList(serializedObject, serializedObject.FindProperty("bossAttribute").FindPropertyRelative("skills"), true, true, true, true);
        robotSkills.elementHeightCallback = (int index) =>
        {
            return 160;
        };
        robotSkills.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = robotSkills.serializedProperty.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, rect.height), element.FindPropertyRelative("skillEvent"));
            Rect cooldownLabel = new Rect(rect.x, rect.y + 85, 200, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(cooldownLabel, "Cooldown", EditorStyles.boldLabel);
            Rect cooldownField = new Rect(cooldownLabel) { x = rect.width, width = 30 };
            EditorGUI.PropertyField(cooldownField, element.FindPropertyRelative("cooldown"), GUIContent.none);
            EditorGUI.LabelField(new Rect(cooldownLabel) { y = cooldownLabel.y + EditorGUIUtility.singleLineHeight + 3 }, "Chance", EditorStyles.boldLabel);
            EditorGUI.PropertyField(new Rect(cooldownField) { y = cooldownField.y + EditorGUIUtility.singleLineHeight + 3 }, element.FindPropertyRelative("chance"), GUIContent.none);
            EditorGUI.LabelField(new Rect(cooldownLabel) { y = cooldownLabel.y + EditorGUIUtility.singleLineHeight * 2 + 6 }, "Trigger Distance", EditorStyles.boldLabel);
            EditorGUI.PropertyField(new Rect(cooldownField) { y = cooldownField.y + EditorGUIUtility.singleLineHeight * 2 + 6 }, element.FindPropertyRelative("triggerDistance"), GUIContent.none);
            EditorGUI.LabelField(new Rect(cooldownLabel) { y = cooldownLabel.y + EditorGUIUtility.singleLineHeight * 3 + 9 }, "Trigger Phase", EditorStyles.boldLabel);
            EditorGUI.PropertyField(new Rect(cooldownField) { x = cooldownField.x - 50, y = cooldownField.y + EditorGUIUtility.singleLineHeight * 3 + 9, width = 80 }, element.FindPropertyRelative("triggerPhase"), GUIContent.none);
        };

        robotSkills.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Robot Skills");
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        robotFold = EditorGUILayout.Foldout(robotFold, "Giant Robot");
        if (robotFold)
        {
            base.OnInspectorGUI();
            EditorGUILayout.HelpBox("Giant Boss. Please refer to excel sheet. LUO Liangzheng", MessageType.None);
            robot.name = EditorGUILayout.TextField("Name", robot.name);
            robot.HP = EditorGUILayout.IntField("HP", robot.HP);
            if (robot.HP < 100)
            {
                if (robot.HP < 0)
                {
                    EditorGUILayout.HelpBox("HP must be over 0.", MessageType.Error);
                }
                else
                {
                    EditorGUILayout.HelpBox("It is sugguested that boss HP not be under 100.", MessageType.Warning);
                }
            }
            robot.speed = EditorGUILayout.FloatField("Basic Speed", robot.speed);
            if (robot.speed < 0)
            {
                EditorGUILayout.HelpBox("Speed must be over 0.", MessageType.Error);
            }
            robot.phase = EditorGUILayout.IntSlider("Phases", robot.phase, 1, 3);
            robotSkills.DoLayoutList();
        }

        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Save"))
        {
            EditorUtility.SetDirty(bossData);
        }
    }
}
