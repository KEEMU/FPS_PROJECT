using UnityEngine;

public interface IEnemyState
{
    EnemyState GetState();
    Enemy Enemy { get; set; }
    void Update();
    void FixedUpdate();
    void OnTriggerEnter(Collider other);
    void OnTriggerExit(Collider other);
    void OnEnter();
    void OnExit();
}

public enum EnemyState : int
{
    Wandering = 0,
    Attacking = 1,
}