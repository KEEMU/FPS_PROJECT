using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy Data/Enemy Attributes", fileName = "Enemy Attributes")]
public class EnemyAttributes : ScriptableObject
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