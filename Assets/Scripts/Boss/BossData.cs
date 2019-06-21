using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Data/Enemy Data/Boss", fileName = "Boss")]
[Serializable]
public class BossData : ScriptableObject
{
    public BossAttribute bossAttribute;
}

[Serializable]
public class BossAttribute
{
    public string name;
    public int HP;
    public float speed;
    [Range(1, 3)]
    public int phase;
    public List<BossSkill> skills;
}

[Serializable]
public struct BossSkill
{
    public UnityEvent skillEvent;
    public void SkillEvent()
    {
        skillEvent = new UnityEvent();
    }
    public int cooldown;
    public float chance;
    public float triggerDistance;
    [EnumFlags]
    public BossPhase triggerPhase;
}

[System.Flags]
public enum BossPhase : int
{
    Phase1 = 1,
    Phase2 = 2,
    Phase3 = 4,
}
