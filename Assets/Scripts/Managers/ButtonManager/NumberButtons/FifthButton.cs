using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthButton : ButtonManager
{
    protected override void Awake()
    {
        inputValue = 5;
        base.Awake();
    }
}
