using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarLook : MonoBehaviour
{
    private Camera playerCamera;
    private void Awake()
    {
        playerCamera = Camera.main;
    }
    private void LateUpdate()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.LookAt(transform.position + playerCamera.transform.rotation * Vector3.forward,
            playerCamera.transform.rotation * Vector3.up);
    }
}
