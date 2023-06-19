using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    private void OnEnable()
    {
        ElevatorInteraction.OnDisablePlayerJoyStick += DisableGameObject;
        PlayerHealth.OnPlayerDeadEvent += DisableGameObject;
    }

    private void DisableGameObject()
    {
        this.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        ElevatorInteraction.OnDisablePlayerJoyStick -= DisableGameObject;
        PlayerHealth.OnPlayerDeadEvent -= DisableGameObject;

    }
}
