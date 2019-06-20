using System;
using UnityEngine;

public class BossRobot : MonoBehaviour
{
    [SerializeField] private BossData bossData;
    private BossAttribute robot;
    private static int phase = 1;
    private static float totalChance = 0f;

    #region Properties
    private static int hp;
    private static float speed;
    #endregion

    #region Skills
    private float skillTimer = 0f;
    #endregion

    void OnEnable()
    {
        robot = bossData.bossAttribute;
        totalChance = 0f;
        foreach (var skill in robot.skills)
        {
            totalChance += skill.chance;
        }
        skillTimer = 0f;
        Debug.Log($"Boss Data: {robot.name}, HP: {robot.HP}, Skills: {robot.skills.Count}");
    }
}