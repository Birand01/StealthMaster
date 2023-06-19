using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPipe : MonoBehaviour
{
    private List<Transform> electricPipes = new List<Transform>();
   
    private void OnEnable()
    {
        ElectricButtonInteraction.OnElectricPipeMovement += PipeMovement;
    }

    private void OnDisable()
    {
        ElectricButtonInteraction.OnElectricPipeMovement -= PipeMovement;

    }
    private  void Awake()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            electricPipes.Add(this.transform.GetChild(i));
        }
    }

    private void PipeMovement()
    {
        foreach (Transform t in electricPipes)
        {
            t.DOMoveX(+6f,6f);
            t.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
