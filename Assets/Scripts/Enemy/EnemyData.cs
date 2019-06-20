using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy Data/Enemy Attributes", fileName = "Enemy Attributes")]
public class EnemyData : ScriptableObject
{
    public EnemyAttribute[] attributes;
}

[Serializable]
public struct EnemyAttribute
{
    public string name;
    public int HP;
    public float speed;
    public EnemyGenre genre;
}


public enum EnemyGenre : int
{
    Melee = 0,
    Ranged = 1,
}