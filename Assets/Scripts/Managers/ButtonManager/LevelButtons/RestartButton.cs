using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : ButtonManager
{
    public delegate void OnRestartButtonClickHandler();
    public static event OnRestartButtonClickHandler OnRestartButtonClick;
    public override void OnButtonClickEvent()
    {
        OnRestartButtonClick?.Invoke();
    }
}
