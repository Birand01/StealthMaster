using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float maxDistance;
    private float conquaredDistance;
    private Rigidbody rb;
    private Vector3 startPosition;

    private void OnEnable()
    {
        BulletInteraction.OnBulletDisable += DisableObject;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        conquaredDistance = Vector3.Distance(transform.position, startPosition);
        if (conquaredDistance > maxDistance)
        {
            DisableObject();
        }
    }

    public void DisableObject()
    {
        rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {       
        BulletInteraction.OnBulletDisable -= DisableObject;
    }
}
