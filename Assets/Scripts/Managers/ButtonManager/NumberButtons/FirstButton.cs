using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstButton : ButtonManager
{
    protected override void Awake()
    {
        inputValue =1;
        base.Awake();
    }

}
