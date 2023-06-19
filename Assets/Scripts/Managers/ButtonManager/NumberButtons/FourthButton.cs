using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthButton : ButtonManager
{
    protected override void Awake()
    {
        inputValue = 4;
        base.Awake();
    }
}
