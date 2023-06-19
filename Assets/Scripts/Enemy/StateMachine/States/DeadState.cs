using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeadState : State
{
   
    private EnemyHealth enemyHealth;
    public DeadState(GameObject obj)
    {
        enemyHealth=obj.GetComponent<EnemyHealth>();
        stateID = StateID.DEAD;
      
    }

    public override void Act()
    {
        Debug.Log("ENEMY IS DEAD");
    }

    public override StateID Decide()
    {
        return StateID.NULL;
    }

    public override void OnEnterState()
    {
        enemyHealth.CheckIfDead();
       
    }

}
