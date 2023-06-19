using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInteraction : InteractionBase
{
    public delegate void OnBulletDisableEventHandler();
    public static event OnBulletDisableEventHandler OnBulletDisable;
    [SerializeField] internal float damage;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            OnBulletDisable?.Invoke();
            damageable.TakeDamage(damage);
        }
    }

   
}
