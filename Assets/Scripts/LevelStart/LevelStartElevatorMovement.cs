using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartElevatorMovement : MonoBehaviour
{
    public delegate void OnLevelStartButtonVisibilityHandler();
    public static event OnLevelStartButtonVisibilityHandler OnLevelStartButton;   

    private void Start()
    {
        MoveElevator();
    }
    private void MoveElevator()
    {
        this.transform.DOMoveY(0f, 3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            OnLevelStartButton?.Invoke();

        });
    }
}
