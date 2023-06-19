using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleJoystick : MonoBehaviour
{
    private void OnEnable()
    {
        StartGameButton.OnJoystickEnability += ScaleJoyStick;
    }
    private void OnDisable()
    {
        StartGameButton.OnJoystickEnability -= ScaleJoyStick;

    }

    private void ScaleJoyStick()
    {
        this.transform.DOScale(1f, 0.5f).SetEase(Ease.InElastic);
    }
}
