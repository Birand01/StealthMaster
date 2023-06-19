
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "ScriptableObjects/PlayerConfiguration", order = 1)]
public class PlayerSO : ScriptableObject
{
    public float speed;
    public float health;
    public float damageToEnemy;
   
    public void SetUpPlayer(PlayerConfiguration playerConfiguration)
    {
        playerConfiguration.GetComponent<PlayerMovement>().moveSpeed = speed;
        playerConfiguration.GetComponent<PlayerHealth>().Health = health;
        playerConfiguration.GetComponent<PlayerHealth>().healthBarSlider.maxValue = health;
        playerConfiguration.GetComponent<PlayerHealth>().healthBarSlider.value = playerConfiguration.GetComponent<PlayerHealth>().Health;
        playerConfiguration.GetComponentInChildren<AttackInteraction>().damageToEnemy = damageToEnemy;
      
    }
}
