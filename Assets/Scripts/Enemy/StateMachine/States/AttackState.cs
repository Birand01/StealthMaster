using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AttackState : State
{
    private EnemyAnimationEvents animationEvents;
    private EnemyUnit unit;
    private EnemyHealth enemyHealth;
    private Light light;
    private FieldOfView fov;
    private Transform _player;
    public AttackState(GameObject obj)
    {
        stateID = StateID.ATTACK;
        animationEvents =obj.GetComponent<EnemyAnimationEvents>();
        unit = obj.GetComponent<EnemyUnit>();
        light = obj.GetComponentInChildren<Light>();
        fov = obj.GetComponent<FieldOfView>();
        enemyHealth = obj.GetComponent<EnemyHealth>();
    }
    public override void Act()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        unit.transform.LookAt(fov.Player.position);
        unit.Attack(fov.Player.GetComponent<IDamageable>(), true);
    }

    public override StateID Decide()
    {
        if (!fov.InFieldOfView() || fov.playerDetected==false)
        {
            return StateID.CHASE;
        }
        if(enemyHealth.Health<=0)
        {
            return StateID.DEAD;
        }
      
        if (_player.gameObject.GetComponent<PlayerHealth>().Health <= 0)
        {
            return StateID.WIN;
        }
        return StateID.NULL;
    }

    public override void OnEnterState()
    {

        light.color = Color.red;
        animationEvents.AttackAnimationEvent(true);
    }

    public override void OnLeaveState()
    {
        light.color = Color.white;
        unit.Attack(fov.Player.GetComponent<IDamageable>(), false);

        animationEvents.AttackAnimationEvent(false);

    }
}
