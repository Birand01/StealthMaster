using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using FSM;

public class StateMachine : MonoBehaviour
{
    public List<Vector3> pathPoints;

    private Dictionary<StateID, State> states;

    private State currentState;
    public State CurrentState { get { return currentState; } }

    void Awake()
    {
        states = new Dictionary<StateID, State>();

        AddState(new PatrolState(gameObject));
        AddState(new AttackState(gameObject));
        AddState(new ChaseState(gameObject));
        AddState(new DeadState(gameObject));
        AddState(new WinState(gameObject));
    }

    private void Update()
    {
        StateID id = currentState.Decide();
        if (id != StateID.NULL)
        {
            PerformTransition(id);
        }
        currentState.Act();
    }

    private void OnDrawGizmosSelected()
    {
        if (pathPoints != null)
        {
            for (int i = 0; i < pathPoints.Count; ++i)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(pathPoints[i], Vector3.one);
                Handles.Label(pathPoints[i] + Vector3.up, i.ToString());
            }
        }

        if (currentState != null)
        {
            Handles.Label(transform.position + Vector3.up, currentState.ID.ToString());
        }
    }

    public void AddState(State s)
    {
        if (s == null)
        {
            Debug.LogError("FSM ERROR: Null reference is not allowed");
        }

        if (states.ContainsKey(s.ID))
        {
            Debug.LogError("FSM ERROR: Impossible to add state " + s.ID.ToString() +
                   " because state has already been added");
            return;
        }
        else if (states.Count == 0)
        {
            currentState = s;
        }

        states.Add(s.ID, s);
    }

    public void DeleteState(StateID id)
    {
        if (id == StateID.NULL)
        {
            Debug.LogError("FSM ERROR: NullStateID is not allowed for a real state");
            return;
        }

        if (!states.ContainsKey(id))
        {
            Debug.LogError("FSM ERROR: Impossible to delete state " + id.ToString() +
                   ". It was not on the list of states");
            return;
        }

        states.Remove(id);

    }

    public void PerformTransition(StateID id)
    {
        if (id == StateID.NULL)
        {
            Debug.LogError("FSM ERROR: NullTransition is not allowed for a real transition");
            return;
        }

        currentState.OnLeaveState();
        currentState = states[id];
        Debug.Log("Changed to state: " + currentState.ID.ToString());
        currentState.OnEnterState();

    }

}
