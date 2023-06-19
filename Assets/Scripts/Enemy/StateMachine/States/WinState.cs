using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : State
{
    private Light light;
    private EnemyAnimationEvents animationEvents;
    
    public WinState(GameObject obj)
    {
        light = obj.GetComponentInChildren<Light>();
        animationEvents=obj.GetComponent<EnemyAnimationEvents>();
        stateID = StateID.WIN;

    }
    public override void Act()
    {
       
    }

    public override StateID Decide()
    {
        return StateID.NULL;
    }

    public override void OnEnterState()
    {
        light.color = Color.green;
        animationEvents.WinAnimation();
    }
    public override void OnLeaveState()
    {
        base.OnLeaveState();
    }
}
