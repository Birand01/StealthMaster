using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        ElevatorInteraction.OnPlayerWinAnimation += WinAnimation;
        PlayerHealth.OnPlayerDeadEvent += DeadAnimation;
        PlayerInput.OnPlayerInput += MovementAnimation;
        AttackInteraction.OnPlayerAttackInteraction += AttackAnimation;
    }

    private void MovementAnimation(Vector3 movementVector)
    {
        if (movementVector.x != 0 || movementVector.z != 0)
        {
            anim.SetFloat("Speed", 1.0f);
        }
        else
        {
            anim.SetFloat("Speed", 0.0f);
        }

    }
   
    private void WinAnimation()
    {
        anim.SetTrigger("Win");
    }
    private void AttackAnimation()
    {
        anim.SetTrigger("Attack");
    }
    private void DeadAnimation()
    {
        anim.SetTrigger("Dead");
    }
    private void OnDisable()
    {
        ElevatorInteraction.OnPlayerWinAnimation -= WinAnimation;
        PlayerHealth.OnPlayerDeadEvent -= DeadAnimation;
        AttackInteraction.OnPlayerAttackInteraction -= AttackAnimation;
        PlayerInput.OnPlayerInput -= MovementAnimation;
    }
}
