using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Data/Enemy Data/Wandering State")]
public class WanderingState : ScriptableObject, IEnemyState
{
    public EnemyState GetState() => EnemyState.Wandering;
    public Enemy Enemy { get; set; }
    private Transform trans = null;
    private NavMeshAgent agent = null;

    [Header("Pathfinding")]
    [SerializeField] private float minDistance = 3f;
    [SerializeField] private float maxDistance = 5f;

    private Vector3 destination = default(Vector3);

    public void OnEnter()
    {
        trans = Enemy.transform;
        agent = agent ?? Enemy.GetComponent<NavMeshAgent>();
        if (destination == default(Vector3))
        {
            destination = GetDestination();
            agent.SetDestination(destination);
        }
    }

    Vector3 GetDestination()
    {
        float r = Random.Range(minDistance, maxDistance);
        int x = Random.value > 0.5f ? 1 : -1;
        int z = Random.value < 0.5f ? 1 : -1;
        return new Vector3(trans.position.x + r * x, trans.position.y, trans.position.z + r * z);
    }

    public void Update()
    {
        float d = Vector3.SqrMagnitude(destination - trans.position);
        if (agent.remainingDistance < 0.1f && agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            destination = GetDestination();
            agent.SetDestination(destination);
            return;
        }
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