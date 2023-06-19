using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    public static event Action<SoundType,bool> OnBombExplodeSound;

    private List<Transform> transforms=new List<Transform>();

    private void OnEnable()
    {
        BombImageFill.OnBombExplode += ResetRigidbody;   
    }

    private void OnDisable()
    {
        BombImageFill.OnBombExplode-= ResetRigidbody;

    }

    private void Awake()
    {
        for (int i = 0; i < this.transform.childCount; i++) 
        { 
            transforms.Add(this.transform.GetChild(i));
        }
    }

    private void ResetRigidbody()
    {
        OnBombExplodeSound?.Invoke(SoundType.BombExplode, true); ;
        foreach (Transform t in transforms)
        {
            t.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            t.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 2000*Time.deltaTime, ForceMode.Impulse);
        }
    }
}
