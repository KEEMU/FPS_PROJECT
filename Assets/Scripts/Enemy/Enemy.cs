using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public EnemyStateMachine stateMachine = null;
    [Header("States")]
    [SerializeField] private WanderingState wanderingState;
    [SerializeField] private AttackingState attackingState;

    void Awake()
    {
        if (!stateMachine)
        {
            stateMachine = new EnemyStateMachine();
        }
        stateMachine.RegisterState(Object.Instantiate(wanderingState));
        stateMachine.RegisterState(Object.Instantiate(attackingState));
    }

    void Start()
    {
        if (stateMachine)
        {
            stateMachine.SwitchState(EnemyState.Attacking);
        }
    }
}
