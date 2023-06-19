using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerConfiguration : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;

    private void OnEnable()
    {
        playerSO.SetUpPlayer(this);
    }

}
