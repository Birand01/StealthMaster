using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordAreaInteraction : InteractionBase
{
    public delegate void OnPasswordPanelActivationHandler(CanvasType canvasType,bool state);
    public static event OnPasswordPanelActivationHandler OnPasswordPanelActivation;

    public delegate void OnClearPasswordTextHandler();
    public static event OnClearPasswordTextHandler OnClearPasswordText;

    private void OnEnable()
    {
        VerifyButton.OnPasswordGateEvent += DisableCollider;
    }
    private void OnDisable()
    {
        VerifyButton.OnPasswordGateEvent -= DisableCollider;

    }
    protected override void OnTriggerEnterAction(Collider collider)
    {
        Debug.Log("PLAYER IS ENTERED");
        OnPasswordPanelActivation?.Invoke(CanvasType.PasswordScreen, true);
    }
    protected override void OnTriggerExitAction(Collider other)
    {
        OnClearPasswordText?.Invoke();
        OnPasswordPanelActivation?.Invoke(CanvasType.PasswordScreen, false);
    }

    private void DisableCollider()
    {
        _collider.enabled = false;
    }
}
