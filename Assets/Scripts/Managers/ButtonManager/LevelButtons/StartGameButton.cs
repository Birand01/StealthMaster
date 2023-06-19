using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : ButtonManager
{
    public delegate void OnJoystickEnabilityHandler();
    public static event OnJoystickEnabilityHandler OnJoystickEnability;

    private void OnEnable()
    {
        LevelStartElevatorMovement.OnLevelStartButton += ScaleButton;
    }
    private void OnDisable()
    {
        LevelStartElevatorMovement.OnLevelStartButton -= ScaleButton;

    }
    public override void OnButtonClickEvent()
    {
        this.gameObject.SetActive(false);
        OnJoystickEnability?.Invoke();
    }

    private void ScaleButton()
    {
        this.transform.DOScale(1, 1f).SetEase(Ease.InFlash);
    }
}
