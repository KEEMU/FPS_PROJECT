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
public struct BossAttribute
{
    public string name;
    public int HP;
    public float speed;
    [Range(1, 3)]
    public int phase;
    public float skillInterval;
    public List<BossSkill> skills;
}

[Serializable]
public struct BossSkill
{
    public UnityEvent skillEvent;
    public int cooldown;
    public float chance;
    public float triggerDistance;
    [EnumFlags]
    public BossPhase triggerPhase;
}

[System.Flags]
public enum BossPhase : int
{
    Phase1 = 0x01,
    Phase2 = 0x02,
    Phase3 = 0x03,
}
