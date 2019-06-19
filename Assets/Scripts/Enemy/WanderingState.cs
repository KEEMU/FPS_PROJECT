using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy Data/Wandering State")]
public class WanderingState : ScriptableObject, IEnemyState
{
    public EnemyState GetState() => EnemyState.Wandering;

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