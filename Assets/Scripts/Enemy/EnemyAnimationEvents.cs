using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour
{
    public delegate void OnEnemyChaseAnimationHandler(GameObject game, string name, bool state);
    public static event OnEnemyChaseAnimationHandler OnEnemyChaseAnimation;
    public delegate void OnEnemyAttackAnimationHandler(GameObject game, string name, bool state);
    public static event OnEnemyAttackAnimationHandler OnEnemyAttackAnimation;

    public delegate void OnEnemyWinAnimationHandler(GameObject game, string name);
    public static event OnEnemyWinAnimationHandler OnEnemyWinAnimation;
    public delegate void OnEnemyDeadAnimationHandler(GameObject game, string name);
    public static event OnEnemyDeadAnimationHandler OnEnemyDeadAnimtion;
    internal void AttackAnimationEvent(bool state)
    {
        OnEnemyAttackAnimation?.Invoke(this.gameObject, "Attack", state);
    }
    internal void ChaseAnimationEvent(bool state)
    {
        OnEnemyChaseAnimation?.Invoke(this.gameObject, "Chase", state);
    }
    internal void DeadAnimation()
    {
        OnEnemyDeadAnimtion?.Invoke(this.gameObject, "Dead");
    }

    internal void WinAnimation()
    {
        OnEnemyWinAnimation?.Invoke(this.gameObject, "Victory");
    }
}
