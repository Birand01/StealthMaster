using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyButton : ButtonManager
{

    // -------------------DELEGATES-------------------
    public delegate void OnPasswordPanelActivationHandler(CanvasType canvasType, bool state);
    public delegate void OnPasswordGateEventHandler();
    public delegate void OnMoveGatePipesHandler();
    public delegate void OnPasswordCorrectSoundHandler(SoundType soundType,bool state);
    public delegate void OnPasswordInCorrectSoundHandler(SoundType soundType, bool state);
    public delegate void OnPasswordImageColorHandler(Color color);
    //-------------------------------------------------

    //-------------------EVENTS-------------------------
    public static event OnPasswordPanelActivationHandler OnPasswordPanelActivation; 
    public static event OnPasswordGateEventHandler OnPasswordGateEvent; 
    public static event OnMoveGatePipesHandler OnMoveGatePipesMovement;
    public static event OnPasswordCorrectSoundHandler OnPasswordCorrectSound;
    public static event OnPasswordInCorrectSoundHandler OnPasswordInCorrectSound;
    public static event OnPasswordImageColorHandler OnPasswordImageColor;
    public override void OnButtonClickEvent()
    {
        if(inputField.text== Password.Instance.GetPasswordText())
        {
            OnPasswordImageColor?.Invoke(Color.green);
            OnPasswordCorrectSound?.Invoke(SoundType.PasswordCorrectSound, true);
            OnPasswordGateEvent?.Invoke();       
            OnMoveGatePipesMovement?.Invoke();
            OnPasswordPanelActivation?.Invoke(CanvasType.PasswordScreen, false);
        }
        else
        {
            OnPasswordImageColor?.Invoke(Color.HSVToRGB(128,61,61));
            OnPasswordInCorrectSound?.Invoke(SoundType.PasswordIncorrectSound, true);
        }
    }
}
