using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAerocraft : MonoBehaviour
{
    public BossData bossData;
    public Text bossName;
    // Start is called before the first frame update

    private BossAttribute aerocraft;

   
    private static int hp;
    private static float speed;
    private static int phase = 1;



    private List<BossSkill> skills;
    private float[] cooldowns;
    private List<int> skillList = new List<int>();
    private float skillTimer;
    private int lastSkill = -1;

    private void OnEnable()
    {
        aerocraft = bossData.bossAttribute;
        skills = aerocraft.skills;
        cooldowns = new float[skills.Count];
        skillTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cooldowns.Length; i++)
        {
            cooldowns[i] += Time.deltaTime;
        }
        skillTimer += Time.deltaTime;
        if (skillTimer > aerocraft.skillInterval)
        {
            skillTimer = 0;
            ExecuteSkill(GetSkills());
        }
    }

    private int GetSkills()
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
        float r = UnityEngine.Random.value * t;
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

    private void ExecuteSkill(int index)
    {
        if (index != -1)
        {
            Debug.Log($"Boss skill: {index}");
            skills[index].skillEvent.Invoke();
        }
    }
}
