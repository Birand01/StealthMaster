using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FSM;
public class PatrolState : State
{
    private EnemyUnit enemyUnit;
    private EnemyHealth enemyHealth;
    private FieldOfView fov;
    private List<Vector3> pathPoints;
    private int currentPoint = 0;

    public PatrolState(GameObject obj)
    {
        stateID = StateID.PATROL;
        enemyHealth = obj.GetComponent<EnemyHealth>();
        enemyUnit = obj.GetComponent<EnemyUnit>();
        fov = obj.GetComponent<FieldOfView>();

        pathPoints = obj.GetComponent<StateMachine>().pathPoints;
    }

    public override void Act()
    {
        if (enemyUnit.NavMeshAgentStopped())
        {
            currentPoint = (currentPoint + 1) % pathPoints.Count;
            enemyUnit.Move(pathPoints[currentPoint]);
        }
    }
    public override StateID Decide()
    {
        if (fov.playerDetected)
        {
            return StateID.CHASE;
        }
        if(enemyHealth.Health<=0)
        {
            return StateID.DEAD;
        }

        return StateID.NULL;
    }
    public override void OnEnterState()
    {
        if (enemyHealth.Health <= 0)
        {
            enemyHealth.CheckIfDead();
        }
          
        enemyUnit.Move(pathPoints[currentPoint]);
    }

    public override void OnLeaveState()
    {
        if(enemyUnit.agent!=null)
        {
            enemyUnit.Move(enemyUnit.transform.position);

        }
    }

    
}
