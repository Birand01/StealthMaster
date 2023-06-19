using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdButton : ButtonManager
{
    protected override void Awake()
    {
        inputValue = 3;
        base.Awake();
    }
}
