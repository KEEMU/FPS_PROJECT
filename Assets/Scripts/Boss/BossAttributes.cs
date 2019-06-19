using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Data/Enemy Data/Boss", fileName = "Boss")]
public class BossAttributes : ScriptableObject
{
    public BossAttribute giantRobot;
}

[Serializable]
public struct BossAttribute
{
    public string name;
    public int HP;
    public float speed;
    public BossSkill[] skills;
}

[Serializable]
public struct BossSkill
{
    public UnityEvent skillEvent;
    public void SkillEvent()
    {
        skillEvent = new UnityEvent();
    }
    public string name;
    public int cooldown;
    public float chance;
    public float triggerDistance;
}
