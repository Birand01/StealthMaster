using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private void Awake()
    {
        if (playerMovement == null)
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
    }
    private void OnEnable()
    {
        PlayerInput.OnPlayerInput += HandleAngularMovement;
        PlayerInput.OnPlayerInput += HandleMovement;
    }
    private void HandleMovement(Vector3 movementVector)
    {
        playerMovement.CharacterMovement(movementVector);
    }
    private void HandleAngularMovement(Vector3 angularMoveVector)
    {
        playerMovement.CharacterAngularMovement(angularMoveVector);
    }

    private void OnDisable()
    {
        PlayerInput.OnPlayerInput -= HandleAngularMovement;
        PlayerInput.OnPlayerInput -= HandleMovement;
    }
}
