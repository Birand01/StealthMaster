using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    private void OnEnable()
    {
        EnemyAnimationEvents.OnEnemyWinAnimation += AnimationTrigger;
        EnemyHealth.OnEnemyDeadAnimation += AnimationTrigger;
        EnemyAnimationEvents.OnEnemyChaseAnimation += AnimationState;
        EnemyAnimationEvents.OnEnemyAttackAnimation += AnimationState;
        //EnemyAnimationEvents.OnEnemyDeadAnimtion += AnimationTrigger;
    }



    private void AnimationState(GameObject gameObject, string name, bool state)
    {
        gameObject.GetComponent<Animator>().SetBool(name, state);
    }
    private void AnimationTrigger(GameObject gameObject, string name)
    {
        gameObject.GetComponent<Animator>().SetTrigger(name);
    }

    private void OnDisable()
    {
        EnemyAnimationEvents.OnEnemyWinAnimation -= AnimationTrigger;
        EnemyHealth.OnEnemyDeadAnimation -= AnimationTrigger;
        EnemyAnimationEvents.OnEnemyChaseAnimation -= AnimationState;
        EnemyAnimationEvents.OnEnemyAttackAnimation -= AnimationState;
        //EnemyAnimationEvents.OnEnemyDeadAnimtion -= AnimationTrigger;

    }
}
