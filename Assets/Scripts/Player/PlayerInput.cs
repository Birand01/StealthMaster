using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void PlayerInputHandler(Vector3 movement);
    public static event PlayerInputHandler OnPlayerInput;


    private FixedJoystick fixedJoystick;
    private Vector3 movementVector;
    private void Awake()
    {
        fixedJoystick = GameObject.FindGameObjectWithTag("FixedJoystick").GetComponent<FixedJoystick>();
    }
    private void FixedUpdate()
    {
        JoyStickMovement(movementVector);
    }

    private void JoyStickMovement(Vector3 moveVector)
    {
        moveVector = Vector3.zero;
        moveVector.x = fixedJoystick.HorizontalAxis();
        moveVector.z = fixedJoystick.VerticalAxis();
        OnPlayerInput?.Invoke(moveVector);
        
    }
}
