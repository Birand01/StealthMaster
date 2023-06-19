using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombImageFill : MonoBehaviour
{
    public delegate void OnBomboExplodeHandler();
    public static event OnBomboExplodeHandler OnBombExplode;

    private SpriteRenderer spriteRenderer;
    private void OnEnable()
    {
        BombAreaInteraction.OnAreaColorChange += ColorChange;
    }
    private void OnDisable()
    {
        BombAreaInteraction.OnAreaColorChange -= ColorChange;

    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void ColorChange()
    {
        spriteRenderer.DOColor(Color.red, 3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            OnBombExplode?.Invoke();
        });
    }
}
