using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy Data/Attacking State")]
public class AttackingState : ScriptableObject, IEnemyState
{
    public EnemyState GetState() => EnemyState.Attacking;

    public void OnEnter()
    {

    }

    public void Update()
    {

    }

    public void FixedUpdate()
    {

    }

    public void OnTriggerEnter()
    {

    }

    public void OnTriggerExit()
    {

    }

    public void OnExit()
    {

    }
}