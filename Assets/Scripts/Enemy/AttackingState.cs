using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Data/Enemy Data/Attacking State")]
public class AttackingState : ScriptableObject, IEnemyState
{
    public EnemyState GetState() => EnemyState.Attacking;
    public Enemy Enemy { get; set; }
    private Transform trans;
    private NavMeshAgent agent;

    public void OnEnter()
    {
        trans = Enemy.transform;
        agent = agent ?? Enemy.GetComponent<NavMeshAgent>();
    }

    public void Update()
    {

    }

    public void FixedUpdate()
    {

    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void OnTriggerExit(Collider other)
    {

    }

    public void OnExit()
    {

    }
}