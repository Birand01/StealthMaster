using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FSM;
public class ChaseState : State
{
   
    private EnemyUnit enemyUnit;
    private FieldOfView fov;
    private float enterStateTime = 0;
    private EnemyAnimationEvents animationEvents;
    public ChaseState(GameObject obj)
    {
        stateID = StateID.CHASE;    
      
        animationEvents=obj.GetComponent<EnemyAnimationEvents>();
        enemyUnit = obj.GetComponent<EnemyUnit>();
        fov = obj.GetComponent<FieldOfView>();
    }

    public override void Act()
    {
        if (!fov.Player.gameObject.activeSelf)
        {
            return;
        }

        if (fov.InFieldOfView())
        {
            enterStateTime += Time.deltaTime;
        }

        enemyUnit.Move(fov.Player.position);


    }

    public override StateID Decide()
    {
        if (!fov.InFieldOfView()  ||  enterStateTime >= enemyUnit.timeToReset)
        {
            enterStateTime = 0f;
            return StateID.PATROL;
        }
        if (enemyUnit.InRange(fov.Player.position))
        {
            return StateID.ATTACK;
        }
        

        return StateID.NULL;
    }

    public override void OnEnterState()
    {
        
        animationEvents.ChaseAnimationEvent(true);
       
    }

    public override void OnLeaveState()
    {
        
        animationEvents.ChaseAnimationEvent(false);
        enterStateTime = 0f;
        enemyUnit.Move(enemyUnit.transform.position);
    }
}
