using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine.Utility;

public class MoneyManager : MonoBehaviour
{
    public delegate void OnMoneyMoveToPlayerHandler(Transform player);
    public static event OnMoneyMoveToPlayerHandler OnMoneyMoveToPlayer;
    [SerializeField] private GameObject moneyPrefab;
    [SerializeField][Range(0f, 10f)] private int minAmount,maxAmount;
    [SerializeField] private int totalMoneyAmount;
    private float totalMoneyToSpawn;
    private Transform _player;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnEnable()
    {
       
        EnemyHealth.OnInstantiateMoney += InstantiateMoney;
    }
   
    private void OnDisable()
    {
       
        EnemyHealth.OnInstantiateMoney -= InstantiateMoney;

    }
    private void OnValidate()
    {
        if (minAmount > maxAmount)
        { minAmount = maxAmount; }
       
    }

    private IEnumerator InstantiateMoney(Transform enemyPosition)
    {
        totalMoneyToSpawn=Random.Range(minAmount,maxAmount);
        int index = 0;
        Debug.Log(totalMoneyToSpawn);
        while(index<totalMoneyToSpawn)
        {
            index++;
            GameObject money = Instantiate(moneyPrefab);       
            money.transform.position= (new Vector3(Random.Range(enemyPosition.localPosition.x+4f, enemyPosition.localPosition.x -4f), 
            enemyPosition.localPosition.y+.5f,Random.Range(enemyPosition.localPosition.z + 3f, enemyPosition.localPosition.z + 4f)));
            money.transform.DOShakePosition(0.4f,1,8,80) ;
           
            money.transform.rotation=Quaternion.Euler(-90f,0,90f);
            yield return new WaitForSeconds(0.1f);
            OnMoneyMoveToPlayer?.Invoke(_player);
        }
      

    }

    

}
