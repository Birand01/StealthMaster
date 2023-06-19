using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConfiguration : MonoBehaviour
{
    [SerializeField] private EnemySO enemySO;

    private void OnEnable()
    {
        enemySO.SetUpEnemy(this);
    }
}
