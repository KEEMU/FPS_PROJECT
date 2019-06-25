using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy Data/Enemy Attributes", fileName = "Enemy Attributes")]
[Serializable]
public class EnemyData : ScriptableObject
{
    public EnemyAttribute attribute;
}

[Serializable]
public struct EnemyAttribute
{
    public string name;
    public int HP;
    public float speed;
    public EnemyGenre genre;
    public float detectRange;
    public float meleeRange;
    public float rangedRange;
    public PatrolStyle patrolStyle;
    public float patrolRange;
    public float chaseRange;
}

public enum EnemyGenre : int
{
    Melee = 0,
    Ranged = 1,
}

public enum PatrolStyle : int
{
    Still = 0,
    Circle = 1,
    Path = 2,
}