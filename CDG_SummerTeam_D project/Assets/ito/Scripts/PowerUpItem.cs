using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [Header("このアイテムの種類")]
    public PowerUpType powerUpType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPowerUp playerPowerUp = other.GetComponent<PlayerPowerUp>();
            if (playerPowerUp != null)
            {
                playerPowerUp.PowerUp(powerUpType);
                Debug.Log($"Player got {powerUpType} PowerUp!");
                Destroy(gameObject);
            }
        }
    }
}
