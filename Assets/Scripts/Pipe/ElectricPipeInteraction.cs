using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class ElectricPipeInteraction : InteractionBase
{
    public delegate void OnScaleHealthBarHandler();
    public static event OnScaleHealthBarHandler OnScaleHealthBar;
    [SerializeField] private float electricPipeDamage;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnScaleHealthBar?.Invoke();
    }

    protected override void OnTriggerStayAction(Collider other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(electricPipeDamage);
        }
        
    }


}
