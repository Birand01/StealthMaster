using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassworField : MonoBehaviour
{
    private InputField inputField;

    private void OnEnable()
    {
        PasswordAreaInteraction.OnClearPasswordText += ClearInputField;
    }

    private void OnDisable()
    {
        PasswordAreaInteraction.OnClearPasswordText -= ClearInputField;
    }
    private void Awake()
    {
        inputField = GetComponent<InputField>();
    }


    private void ClearInputField()
    {
        inputField.text = "";
    }
}
