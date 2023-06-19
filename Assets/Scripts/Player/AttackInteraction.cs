using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInteraction : InteractionBase
{
    //--------------------DELEGATES----------------------
    public delegate void OnPlayerAttackAnimationHandler();
    public delegate void OnSamuraiHitSoundHandler(SoundType soundType, bool state);
    //----------------------------------------------------

    //-------------------- EVENTS--------------------------
    public static event OnPlayerAttackAnimationHandler OnPlayerAttackInteraction;
    public static event OnSamuraiHitSoundHandler OnSamuraiHitSound;
    //------------------------------------------------------
    internal float damageToEnemy;
   
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnSamuraiHitSound?.Invoke(SoundType.SamuraHitSound, true);
        OnPlayerAttackInteraction?.Invoke();
        IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damageToEnemy);
        }
    }
    protected override void OnTriggerExitAction(Collider other)
    {
        OnSamuraiHitSound?.Invoke(SoundType.SamuraHitSound, false);
    }

}
