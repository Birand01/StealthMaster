using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : InteractionBase
{
  
    public delegate void OnDoorSoundHandler(SoundType soundType, bool state);
    public static event OnDoorSoundHandler OnDoorSound;
   
    protected override void OnTriggerEnterAction(Collider collider)
    {
        IPickable pickable = collider.GetComponentInChildren<IPickable>();
        if (pickable != null && pickable.GetTransform().name=="Key")
        {
            MoveDoor();
            pickable.GetCollider().enabled = false;
            pickable.GetTransform().gameObject.SetActive(false);
            pickable.GetTransform().SetParent(null);
        }

    }

    private void MoveDoor()
    {
      
            OnDoorSound?.Invoke(SoundType.DoorSound, true);
            this.transform.DOMoveX(-0.5f, 1f);
       
    }
}
