using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionBase : MonoBehaviour
{
   
    protected Collider _collider = null;
    protected virtual void Awake()
    {
        _collider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterAction(other);
      
    }
    private void OnTriggerStay(Collider other)
    {
        OnTriggerStayAction(other);
    }
    private void OnTriggerExit(Collider other)
    {
        OnTriggerExitAction(other);
    }

    protected virtual void OnTriggerStayAction(Collider other) { }
    protected virtual void OnTriggerExitAction(Collider other) { }
    protected abstract void OnTriggerEnterAction(Collider collider);

    private void Reset()
    {
        // set isTrigger in the Inspector, just in case Designer forgot
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }
}
