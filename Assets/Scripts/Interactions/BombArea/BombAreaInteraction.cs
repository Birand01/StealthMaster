using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAreaInteraction : InteractionBase
{
    public delegate void OnAreaColorChangeHandler();
    public static event OnAreaColorChangeHandler OnAreaColorChange;
    protected override void OnTriggerEnterAction(Collider collider)
    {
       IPickable pickable=collider.GetComponentInChildren<IPickable>();
        if(pickable != null && pickable.GetTransform().name=="Bomb")
        {

            pickable.GetTransform().DOJump(this.transform.position, 2, 2, 0.4f).SetEase(Ease.Linear).OnComplete(() =>
            {
                pickable.SetPosition(this.transform);
                pickable.GetCollider().enabled = false;
            }).OnComplete(() =>
            {
                pickable.GetTransform().gameObject.SetActive(false);
                OnAreaColorChange?.Invoke();
            }); 
            
        }
    }
}
