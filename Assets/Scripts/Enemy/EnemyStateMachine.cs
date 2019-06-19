using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private IEnemyState currentState = null;
    public IEnemyState CurrentState { get => currentState; }
    private Dictionary<EnemyState, IEnemyState> stateDictionary = null;

    public EnemyStateMachine()
    {
        stateDictionary = new Dictionary<EnemyState, IEnemyState>();
    }

    internal IEnemyState GetState(EnemyState s)
    {
        IEnemyState state = null;
        stateDictionary.TryGetValue(s, out state);
        return state;
    }

    internal bool RegisterState(IEnemyState state)
    {
        if (state == null) return false;
        if (stateDictionary.ContainsKey(state.GetState())) return false;
        stateDictionary.Add(state.GetState(), state);
        return true;
    }

    internal bool SwitchState(EnemyState to)
    {
        if (currentState != null && currentState.GetState() == to) return false;
        IEnemyState newState = null;
        stateDictionary.TryGetValue(to, out newState);
        if (newState == null) return false;
        IEnemyState oldState = currentState;
        oldState.OnExit();
        currentState = newState;
        newState.OnEnter();
        return true;
    }
}
