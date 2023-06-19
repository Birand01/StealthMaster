using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMovement : InteractionBase
{
    private Transform _player;
    protected override void Awake()
    {
        base.Awake();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    protected override void OnTriggerEnterAction(Collider collider)
    {
        collider.transform.DOMove(_player.position, 1f).SetEase(Ease.OutElastic);
    }
}
