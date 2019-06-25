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
    private List<float> cooldowns;
    private List<float> skillList;
    private float skillTimer = 0f;
    #endregion

    void OnEnable()
    {
        robot = bossData.bossAttribute;
        skills = robot.skills;
        cooldowns = new List<float>(skills.Count);
        skillTimer = 0f;
        Debug.Log($"Boss Data: {robot.name}, HP: {robot.HP}, Skills: {robot.skills.Count}");
    }

    void Update()
    {
        for (int i = 0; i < cooldowns.Count; i++)
        {
            cooldowns[i] += Time.deltaTime;
        }
        ExecuteSkill(GetSkills());
    }

    int GetSkills()
    {
        var t = 0f;
        for (int i = 0; i < skills.Count; i++)
        {
            if (cooldowns[i] > skills[i].cooldown)
            {
                skillList.Add(skills[i].chance);
                t += skills[i].chance;
                float r = Random.value * t;
                for (int j = 0; j < skillList.Count; j++)
                {
                    if (r < skillList[j]) return j;
                    else
                    {
                        r -= skillList[j];
                    }
                }
                return skillList.Count - 1;
            }
        }
        return -1;
    }

    void ExecuteSkill(int index)
    {
        if (index != -1)
        {
            skills[index].skillEvent.Invoke();
        }
    }

    void FixedUpdate()
    {

    }
}