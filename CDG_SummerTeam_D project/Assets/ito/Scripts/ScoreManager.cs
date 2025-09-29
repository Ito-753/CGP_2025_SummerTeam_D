using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }

    private PlayerPowerUp playerPower;

    void Start()
    {
        // プレイヤーを探して PowerUp スクリプトを取得
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerPower = player.GetComponent<PlayerPowerUp>();
        }

        Score = 0;
    }

    public void AddScore(int baseScore)
    {
        int multiplier = 1;

        if (playerPower != null)
        {
            multiplier = playerPower.currentScoreMultiplier;
        }

        int addedScore = baseScore * multiplier;
        Score += addedScore;

        Debug.Log($"Score +{addedScore} (base:{baseScore} × {multiplier}倍) → Total:{Score}");
    }
}
