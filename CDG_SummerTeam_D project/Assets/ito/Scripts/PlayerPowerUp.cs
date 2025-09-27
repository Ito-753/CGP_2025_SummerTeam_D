using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    private bool hasSpeed = false;
    private bool hasAttackPower = false;
    private bool hasAttackRange = false;
    private bool hasScoreBonus = false;
    private bool hasWallHack = false;

    // 強化後の固定値
    public float boostedSpeed = 10f;
    public float boostedAttackPower = 20f;
    public float boostedAttackRange = 3f;
    public int boostedScoreBonus = 2;

    // もともとの値
    private float defaultSpeed = 5f;
    private float defaultAttackPower = 10f;
    private float defaultAttackRange = 1f;
    private int defaultScoreBonus = 1;

    // 実際に使う値
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public float currentAttackPower;
    [HideInInspector] public float currentAttackRange;
    [HideInInspector] public int currentScoreBonus;

    void Start()
    {
        ResetPowerUps();
    }

    public void PowerUp(PowerUpType type)
    {
        switch (type)
        {
            case PowerUpType.Speed:
                hasSpeed = true;
                currentSpeed = boostedSpeed;
                break;

            case PowerUpType.AttackPower:
                hasAttackPower = true;
                currentAttackPower = boostedAttackPower;
                break;

            case PowerUpType.AttackRange:
                hasAttackRange = true;
                currentAttackRange = boostedAttackRange;
                break;

            case PowerUpType.Score:
                hasScoreBonus = true;
                currentScoreBonus = boostedScoreBonus;
                break;

            case PowerUpType.WallHack:
                hasWallHack = true;
                // ここで「壁を透過して見える」処理を呼び出す
                break;
        }
    }

    public void ResetPowerUps()
    {
        hasSpeed = false;
        hasAttackPower = false;
        hasAttackRange = false;
        hasScoreBonus = false;
        hasWallHack = false;

        currentSpeed = defaultSpeed;
        currentAttackPower = defaultAttackPower;
        currentAttackRange = defaultAttackRange;
        currentScoreBonus = defaultScoreBonus;
    }
}
