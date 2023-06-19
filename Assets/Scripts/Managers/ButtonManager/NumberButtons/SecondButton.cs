using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondButton : ButtonManager
{
    protected override void Awake()
    {
        inputValue = 2;
        base.Awake();
    }
}
