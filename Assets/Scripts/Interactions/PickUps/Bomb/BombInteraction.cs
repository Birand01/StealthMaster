using Cinemachine.Utility;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInteraction : InteractionBase, IPickable
{
    public static event Action<SoundType, bool> OnBombPickUpSound;
    private Transform pickUpParent;
    protected override void Awake()
    {
        pickUpParent = GameObject.FindGameObjectWithTag("PickUpParent").transform;
        base.Awake();
    }
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnBombPickUpSound?.Invoke(SoundType.BombPickUp, true);
        this.transform.DOJump(new Vector3(pickUpParent.position.x,pickUpParent.position.y,
            pickUpParent.position.z),2,2, 0.2f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            SetPosition(pickUpParent);

        });
       
    }

    public void SetPosition(Transform parent)
    {
        this.transform.SetParent(parent);
    }

    public Transform GetTransform()
    {
        return this.transform;
    }

    public Collider GetCollider()
    {
        return _collider;
    }
}
