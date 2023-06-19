using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelButton : ButtonManager
{
    public delegate void OnNextLevelButtonHandler();
    public static event OnNextLevelButtonHandler OnNextLevelButton;

    public override void OnButtonClickEvent()
    {
       OnNextLevelButton?.Invoke();
    }
}
