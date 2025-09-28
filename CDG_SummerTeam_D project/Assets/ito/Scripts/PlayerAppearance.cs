using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    [Header("パワーアップ見た目パーツ")]
    [SerializeField] private GameObject speedUp;   // Speed
    [SerializeField] private GameObject powerUp;   // AttackPower
    [SerializeField] private GameObject scoreUp;   // Score
    [SerializeField] private GameObject wallHack;  // WallHack

    private void Start()
    {
        HideAllParts();
    }

    private void HideAllParts()
    {
        if (speedUp) speedUp.SetActive(false);
        if (powerUp) powerUp.SetActive(false);
        if (scoreUp) scoreUp.SetActive(false);
        if (wallHack) wallHack.SetActive(false);
    }

    public void ApplyPowerUp(PowerUpType type)
    {
        switch (type)
        {
            case PowerUpType.Speed:
                if (speedUp) speedUp.SetActive(true);
                break;
            case PowerUpType.AttackPower:
                if (powerUp) powerUp.SetActive(true);
                break;
            case PowerUpType.Score:
                if (scoreUp) scoreUp.SetActive(true);
                break;
            case PowerUpType.WallHack:
                if (wallHack) wallHack.SetActive(true);
                break;
        }
    }
}
