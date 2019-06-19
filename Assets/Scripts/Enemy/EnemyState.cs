using UnityEngine;

public interface IEnemyState
{
    EnemyState GetState();
    void Update();
    void FixedUpdate();
    void OnTriggerEnter();
    void OnTriggerExit();
    void OnEnter();
    void OnExit();
}

public enum EnemyState : int
{
    Wandering = 0,
    Attacking = 1,
}