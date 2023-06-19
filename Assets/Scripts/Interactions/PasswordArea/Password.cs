using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Password : MonoBehaviour
{
    private TMP_Text passwordText;

    public static Password Instance { get; private set; }   
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        passwordText = GetComponent<TMP_Text>();
    }

    public string GetPasswordText()
    {
        return passwordText.text;
    }

}
