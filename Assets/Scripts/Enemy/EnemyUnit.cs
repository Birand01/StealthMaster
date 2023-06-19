using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUnit : MonoBehaviour
{
    internal NavMeshAgent agent;
    internal float timeToReset = 3f; 
    internal float attackRange = 9;
    private Gun gun;
    protected virtual void Awake()
    {
        gun = GetComponentInChildren<Gun>();
        agent = GetComponent<NavMeshAgent>();
    }
    
    public virtual void Attack(IDamageable target,bool state)
    {
        gun.Shoot(target, state);
    }
    public virtual void Move(Vector3 destination)
    {
        
        if(agent.enabled!=false)
        {
            agent.SetDestination(destination);
        }
        else 
        {
            return;
        }
       
      
    }
    internal bool NavMeshAgentStopped()
    {
        return (Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance);
    }

    public bool InRange(Vector3 position)
    {
        return Vector3.Distance(position, transform.position) <= attackRange;
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward*attackRange, Color.green);
    }
}
