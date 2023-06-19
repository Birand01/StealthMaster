using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBlock : MonoBehaviour
{

    private void OnEnable()
    {
        BombImageFill.OnBombExplode += Disable;
    }

    private void OnDisable()
    {
        BombImageFill.OnBombExplode -= Disable;
    }
    

    private void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
