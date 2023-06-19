using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeColor : MonoBehaviour
{
    private List<Transform> pipelist=new List<Transform>();
    private void OnEnable()
    {
        ElectricButtonInteraction.OnPipeColorFade += ColorFade;
    }
    private void OnDisable()
    {
        ElectricButtonInteraction.OnPipeColorFade -= ColorFade;

    }
    private void Awake()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            pipelist.Add(transform.GetChild(i));
        }
    }


    private void ColorFade(Color color)
    {
        foreach (Transform pipe in pipelist)
        {
            pipe.gameObject.GetComponent<Renderer>().material.DOColor(Color.grey, 2f);
        }
    }
}
