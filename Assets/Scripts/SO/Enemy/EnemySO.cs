
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "EnemyConfiguration", menuName = "ScriptableObjects/EnemyConfiguration", order = 2)]
public class EnemySO : ScriptableObject
{
    public float speed;
    public float angularSpeed;
    public float acceleration;
    public float timeToReset;
    public float attackRange;
    //public float viewDistance;
    //public float viewAngle;
    public float searchDelay;
    public float health;
    public LayerMask obstructionMask;
    public GameObject bulletPrefab;
    public float reloadDelay;
    public float bulletSpeed;
    //public List<Vector3> pathPoints;

    public void SetUpEnemy(EnemyConfiguration enemyConfiguration)
    {
        enemyConfiguration.GetComponent<NavMeshAgent>().speed = speed;
        enemyConfiguration.GetComponent<NavMeshAgent>().angularSpeed = angularSpeed;
        enemyConfiguration.GetComponent<NavMeshAgent>().acceleration = acceleration;
        enemyConfiguration.GetComponent<EnemyUnit>().timeToReset = timeToReset;
        enemyConfiguration.GetComponent<EnemyUnit>().attackRange = attackRange;
        //enemyConfiguration.GetComponent<FieldOfView>().viewDistance = viewDistance;
        //enemyConfiguration.GetComponent<FieldOfView>().viewAngle = viewAngle;
        enemyConfiguration.GetComponent<FieldOfView>().searchDelay = searchDelay;      
        enemyConfiguration.GetComponent<FieldOfView>().obstructionMask = obstructionMask;
        enemyConfiguration.GetComponentInChildren<Gun>().bulletPrefab = bulletPrefab;
        enemyConfiguration.GetComponentInChildren<Gun>().bulletSpeed = bulletSpeed;
        enemyConfiguration.GetComponentInChildren<Gun>().reloadDelay = reloadDelay;
        enemyConfiguration.GetComponent<EnemyHealth>().Health = health;
        enemyConfiguration.GetComponent<EnemyHealth>().healthBarSlider.maxValue = health;
        enemyConfiguration.GetComponent<EnemyHealth>().healthBarSlider.value = enemyConfiguration.GetComponent<EnemyHealth>().Health;
        //enemyConfiguration.GetComponent<StateMachine>().pathPoints = pathPoints;
    }
}
