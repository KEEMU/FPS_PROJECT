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
    public EnemyGenre genre;
    public int HP;
    public float speed;
    public float detectRange;
    public float meleeRange;
    public float rangedRange;
}

public enum EnemyGenre : int
{
    Melee = 0,
    Ranged = 1,
}