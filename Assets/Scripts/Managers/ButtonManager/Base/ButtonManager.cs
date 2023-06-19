using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class ButtonManager : MonoBehaviour
{
    protected int inputValue;
    protected InputField inputField;
    protected Button button;

    protected virtual void Awake()
    {
        if(inputField == null)
        {
            inputField = GameObject.FindGameObjectWithTag("InputField").GetComponent<InputField>();
        }
        inputField.characterLimit = 6;
        button = GetComponent<Button>();
    }

    protected virtual void Start()
    {
        button.onClick.AddListener(OnButtonClickEvent);
    }


    public virtual void OnButtonClickEvent()
    {
        inputField.text += inputValue.ToString();
    }
}
