using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : InteractionBase,IPickable
{
    public delegate void OnKeySoundHandler(SoundType soundType, bool state);
    public static event OnKeySoundHandler OnKeySound;

    private Transform pickUpParent;
    protected override void Awake()
    {
        base.Awake();
        pickUpParent = GameObject.FindGameObjectWithTag("PickUpParent").transform;

    }
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnKeySound?.Invoke(SoundType.KeySound, true);
        this.transform.DOJump(new Vector3(pickUpParent.position.x, pickUpParent.position.y,
           pickUpParent.position.z), 2, 2, 0.2f).SetEase(Ease.OutBounce).OnComplete(() =>
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

