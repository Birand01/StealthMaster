using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : HealthBase
{

    //--------------------DELEGATES-----------------------
    public delegate void OnEnemyDeadAnimationHandler(GameObject gameObject, string name);
    public delegate void OnEnemyDeadParticleHandler(int index, Vector3 position);
    public delegate IEnumerator OnInstantiateMoneyHandler(Transform transform);
    public delegate void OnEnemyDeadCounterEventHandler();

    //----------------------------------------------------
    public static event OnEnemyDeadAnimationHandler OnEnemyDeadAnimation;
    public static event OnEnemyDeadParticleHandler OnEnemyDeadParticle;
    public static event OnInstantiateMoneyHandler OnInstantiateMoney;
    public static event OnEnemyDeadCounterEventHandler OnEnemyDeadCounter;
    private void OnEnable()
    {
        AttackInteraction.OnPlayerAttackInteraction += ScaleHealthBar;
    }
    protected override internal void CheckIfDead()
    {
        if(Health<=0)
        {
           
            StartCoroutine(DeadEventCoroutine());

        }
    }

   
    private IEnumerator DeadEventCoroutine()
    {
       
        this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;
        this.gameObject.GetComponentInChildren<Light>().intensity = 0f;
        OnEnemyDeadAnimation?.Invoke(this.gameObject, "Dead");       
        yield return new WaitForSeconds(0.3f);      
        StartCoroutine( OnInstantiateMoney?.Invoke(this.transform));
        OnEnemyDeadParticle?.Invoke(0, this.transform.position);
        yield return new WaitForSeconds(4f);
        this.gameObject.SetActive(false);
        OnEnemyDeadCounter?.Invoke();

    }
    
    private void OnDisable()
    {
        AttackInteraction.OnPlayerAttackInteraction -= ScaleHealthBar;

    }
}
