using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerHealth : HealthBase
{
    public delegate void OnLevelFailPanelHandler(CanvasType canvasType, bool state);
    public static event OnLevelFailPanelHandler OnLevelFailPanel;

    public delegate void OnPlayerDeadEventHandler();
    public static event OnPlayerDeadEventHandler OnPlayerDeadEvent;
   
    private void OnEnable()
    {
        ElectricPipeInteraction.OnScaleHealthBar += ScaleHealthBar;
        BulletInteraction.OnBulletDisable += ScaleHealthBar;
    }
    protected override internal void CheckIfDead()
    {
        Debug.Log("Player is dead");
        if(Health<=0)
        {
            this.gameObject.GetComponent<Collider>().enabled = false;
            OnPlayerDeadEvent?.Invoke();
            OnLevelFailPanel?.Invoke(CanvasType.GameFailScreen, true);
        }
    }
  
    private void OnDisable()
    {
        ElectricPipeInteraction.OnScaleHealthBar -= ScaleHealthBar;
        BulletInteraction.OnBulletDisable -= ScaleHealthBar;
    }


}
