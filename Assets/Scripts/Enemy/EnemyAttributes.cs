using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy Data", fileName = "Data/Enemy Data")]
public class EnemyAttribute : ScriptableObject
{
    public int HP;
    public float speed;
    public EnemyGenre genre;
}

public enum EnemyGenre : int
{
    Melee = 0,
    Ranged = 1,
}