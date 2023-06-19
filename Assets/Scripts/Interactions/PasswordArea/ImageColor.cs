using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ImageColor : MonoBehaviour
{
    private Renderer _renderer;
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    private void OnEnable()
    {
        VerifyButton.OnPasswordImageColor += ColorChange;

    }
    private void OnDisable()
    {
        VerifyButton.OnPasswordImageColor -= ColorChange;
    }
   

    private void ColorChange(Color color)
    {
        _renderer.material.DOColor(color, 3f);
    }
}
