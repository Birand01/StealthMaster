using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PipeMovement : MonoBehaviour
{
    private BoxCollider boxCollider;
    private List<Transform> pipeTransforms = new List<Transform>();


    private void OnEnable()
    {
       
        VerifyButton.OnMoveGatePipesMovement += PipeMovementEvent;
    }
    private void OnDisable()
    {
        VerifyButton.OnMoveGatePipesMovement -= PipeMovementEvent;
    }
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        for (int i = 0; i < transform.childCount; i++)
        {
            pipeTransforms.Add(transform.GetChild(i));
        }
    }
    
    private void PipeMovementEvent()
    {
        boxCollider.enabled = false;
       StartCoroutine( MovingPipes());
    }
    private IEnumerator MovingPipes()
    {
        for (int i = 0; i < pipeTransforms.Count; i++)
        {
            Sequence sequence = DOTween.Sequence();
            pipeTransforms[i].transform.DOLocalMoveY(-1.5f,0.3f);

            sequence.Append(pipeTransforms[i].GetComponent<Renderer>().material.DOColor(Color.green, 0.5f));
            sequence.Append(pipeTransforms[i].GetComponent<Renderer>().material.DOColor(Color.black, 0.5f));

            yield return new WaitForSeconds(0.1f);
        }
    }
}
