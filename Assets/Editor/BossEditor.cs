using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BossData))]
[CanEditMultipleObjects]
public class BossEditor : Editor
{
    BossData bossData;

    void OnEnable()
    {
        bossData = (BossData)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        base.OnInspectorGUI();
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(bossData);
    }
}
