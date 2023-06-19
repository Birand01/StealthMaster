using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorInteraction : InteractionBase
{

    //-------------------- DELEGATES ---------------------
    public delegate void OnElevatorSoundHandler(SoundType soundType, bool state);
    public delegate void OnDisablePlayerJoyStickHandler();
    public delegate void OnPlayerWinAnimationHandler();
    public delegate void OnLevelSuccessPanelActivationHandler(CanvasType type,bool state);

    //----------------------------------------------------

    //-------------------- EVENTS -------------------------
    public static event OnElevatorSoundHandler OnElevatorSound;     
    public static event OnDisablePlayerJoyStickHandler OnDisablePlayerJoyStick;
    public static event OnPlayerWinAnimationHandler OnPlayerWinAnimation;
    public static event OnLevelSuccessPanelActivationHandler OnLevelSuccessPanelActivation;

    private Transform movePoint,elevatorDoor,elevatorGround;

    protected override void Awake()
    {
        base.Awake();
        movePoint = GameObject.FindGameObjectWithTag("MovePoint").transform;
        elevatorDoor = GameObject.FindGameObjectWithTag("ElevatorDoor").transform;
        elevatorGround = GameObject.FindGameObjectWithTag("ElevatorGround").transform;

    }

    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnDisablePlayerJoyStick?.Invoke();
        if (CounterManager.Instance.enemyLeft==0)
        {
            elevatorDoor.DOMoveX(-2.5f, 0.4f).SetEase(Ease.Linear).OnComplete(() =>
            {
                OnElevatorSound?.Invoke(SoundType.ElevatorSound, true);
                collider.transform.DOMove(movePoint.position, 2f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    OnPlayerWinAnimation?.Invoke();
                    elevatorDoor.DOMoveX(4f, 0.3f).SetEase(Ease.OutExpo);
                    elevatorGround.DOMoveY(10f,3f).SetEase(Ease.Linear).OnComplete(()=>
                    {

                        OnLevelSuccessPanelActivation?.Invoke(CanvasType.GameSuccessScreen, true);
                    });
               });
            });
    }

    }
}
