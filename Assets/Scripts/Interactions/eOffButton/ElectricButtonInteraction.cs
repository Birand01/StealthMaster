using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricButtonInteraction : InteractionBase
{
    public delegate void OnPipeColorFadeHandler(Color color);
    public static event OnPipeColorFadeHandler OnPipeColorFade;
    public delegate void OnElectricPipeMovementHandler();
    public static event OnElectricPipeMovementHandler OnElectricPipeMovement;
    public delegate void OnElectricGateSoundHandler(SoundType soundType, bool state);
    public static event OnElectricGateSoundHandler OnElectricGateSound;
    Renderer meshRenderer;
    protected override void Awake()
    {
        base.Awake();
        meshRenderer = GetComponent<Renderer>();
    }
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnElectricGateSound?.Invoke(SoundType.ElectricGateSound, true);
        OnElectricPipeMovement?.Invoke();
        OnPipeColorFade?.Invoke(Color.grey);
        meshRenderer.material.DOColor(Color.grey,2f);
        this.transform.DOLocalMoveY(-0.9f, 0.5f);
    }
}
