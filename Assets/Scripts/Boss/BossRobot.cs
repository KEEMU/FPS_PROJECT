using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRobot : MonoBehaviour
{
    [SerializeField] private BossData bossData;
    [SerializeField] private Text bossName;

    private BossAttribute robot;

    #region Properties
    private static int hp;
    private static float speed;
    private static int phase = 1;
    #endregion

    #region Skills
    private List<BossSkill> skills;
    private float[] cooldowns;
    private List<int> skillList = new List<int>();
    private float skillTimer = 0;
    private int lastSkill = -1;
    #endregion

    void OnEnable()
    {
        robot = bossData.bossAttribute;
        skills = robot.skills;
        cooldowns = new float[skills.Count];
        skillTimer = 0;
    }

    void Update()
    {
        for (int i = 0; i < cooldowns.Length; i++)
        {
            cooldowns[i] += Time.deltaTime;
        }
        skillTimer += Time.deltaTime;
        if (skillTimer > robot.skillInterval)
        {
            skillTimer = 0;
            ExecuteSkill(GetSkills());
        }
    }

    int GetSkills()
    {
        var t = 0f;
        float[] chanceArray = new float[skills.Count];
        for (int i = 0; i < skills.Count; i++)
        {
            if (cooldowns[i] > skills[i].cooldown)
            {
                skillList.Add(i);
                chanceArray[i] = skills[i].chance;
                t += skills[i].chance;
            }
        }
        if (skillList.Count == 0) return -1;
        int skillIndex = -1;
        float r = Random.value * t;
        for (int j = 0; j < skillList.Count; j++)
        {
            if (r < chanceArray[skillList[j]])
            {
                cooldowns[skillList[j]] = 0;
                skillIndex = skillList[j];
                skillList.Clear();
                return skillIndex;
            }
            else
            {
                r -= chanceArray[skillList[j]];
            }
        }
        cooldowns[skillList[skillList.Count - 1]] = 0;
        skillIndex = skillList[skillList.Count - 1];
        skillList.Clear();
        return skillIndex;
    }

    void ExecuteSkill(int index)
    {
        if (index != -1)
        {
            Debug.Log($"Boss skill: {index}");
            skills[index].skillEvent.Invoke();
        }
    }

    void FixedUpdate()
    {

    }
}