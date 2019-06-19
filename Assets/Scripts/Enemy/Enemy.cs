using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public EnemyStateMachine stateMachine = null;
    [SerializeField] private EnemyAttributes enemyAttribute;
    [Header("States")]
    [SerializeField] private WanderingState wanderingState;
    [SerializeField] private AttackingState attackingState;

    private Rigidbody rb;

    void Awake()
    {
        if (stateMachine == null)
        {
            stateMachine = new EnemyStateMachine();
        }
        stateMachine.RegisterState(Object.Instantiate(wanderingState), this);
        stateMachine.RegisterState(Object.Instantiate(attackingState), this);
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (stateMachine != null)
        {
            stateMachine.SwitchState(EnemyState.Wandering);
        }
    }

    void Update()
    {
        stateMachine.CurrentState.Update();
        Debug.DrawRay(transform.position, rb.velocity);
    }

    void FixedUpdate()
    {
        stateMachine.CurrentState.FixedUpdate();
    }

    void OnTriggerEnter(Collider other)
    {
        stateMachine.CurrentState.OnTriggerEnter(other);
    }

    void OnTriggerExit(Collider other)
    {
        stateMachine.CurrentState.OnTriggerExit(other);
    }
}
