using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : ButtonManager
{
    public delegate void OnMainMenuSceneHandler();
    public static OnMainMenuSceneHandler OnMainMenuScene;  
    public override void OnButtonClickEvent()
    {
        OnMainMenuScene?.Invoke();
    }
}
