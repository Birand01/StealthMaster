using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoneyInteraction : InteractionBase
{
    public delegate void OnMoneyValueHandler(int value);
    public static event OnMoneyValueHandler OnMoneyValue;

    private void OnEnable()
    {
        MoneyManager.OnMoneyMoveToPlayer += MoveToPlayer;
    }
    private void OnDisable()
    {
        MoneyManager.OnMoneyMoveToPlayer -= MoveToPlayer;

    }
    protected override void OnTriggerEnterAction(Collider collider)
    {
        MoveToPlayer(collider.transform);
        OnMoneyValue?.Invoke(1);
        this.gameObject.GetComponent<Collider>().isTrigger = false;
        this.gameObject.SetActive(false);
    }


    private void MoveToPlayer(Transform transform)
    {
        this.transform.DOJump(transform.position, 1f, 2, 0.4f);
        this.transform.DOMove(transform.position,0.3f);
        // this.transform.DORotate(transform.position, .1f, RotateMode.Fast);
    }

    
   
}
