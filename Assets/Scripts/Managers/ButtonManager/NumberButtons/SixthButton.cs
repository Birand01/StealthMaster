using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthButton : ButtonManager
{
    protected override void Awake()
    {
        inputValue = 6;
        base.Awake();
    }
}
