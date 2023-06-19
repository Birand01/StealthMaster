using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
   

    private TMP_Text moneyCountText, enemyCountText;
    private GameObject[] enemies;
    public int enemyLeft;
    public static CounterManager Instance { get; private set; } 
    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        moneyCountText = GameObject.FindGameObjectWithTag("MoneyText").GetComponent<TMP_Text>();
        enemyCountText = GameObject.FindGameObjectWithTag("EnemyText").GetComponent<TMP_Text>();

    }

  
    public int MoneyCount { get; set; } = 0;
  
    private void Start()
    {
        enemyLeft = enemies.Length;
        enemyCountText.text=enemyLeft.ToString();
    }
    private void OnEnable()
    {
        EnemyHealth.OnEnemyDeadCounter += DecreaseEnemy;
        MoneyInteraction.OnMoneyValue += TotalMoney;
    }
    private void OnDisable()
    {
        EnemyHealth.OnEnemyDeadCounter -= DecreaseEnemy;
        MoneyInteraction.OnMoneyValue -= TotalMoney;
    }
    private void TotalMoney(int moneyValue)
    {
        MoneyCount += moneyValue;
        PlayerPrefs.SetInt("GoldCount", MoneyCount);
        moneyCountText.text= MoneyCount.ToString();
       
    }
    private void DecreaseEnemy()
    {
        enemyLeft--;
        enemyLeft = Mathf.Clamp(enemyLeft, 0, enemies.Length);
        enemyCountText.text = enemyLeft.ToString();
    }

    
}
