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
    public int boostedScoreMultiplier = 2;

    // もともとの値
    private float defaultSpeed = 5f;
    private float defaultAttackPower = 10f;
    private float defaultAttackRange = 1f;
    private int defaultScoreMultiplier = 1;
    // 実際に使う値
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public float currentAttackPower;
    [HideInInspector] public float currentAttackRange;
    [HideInInspector] public int currentScoreMultiplier;

    private Outline[] wallVisionTargets;
    private PlayerAppearance appearance;

        void Awake()
    {
        appearance = GetComponent<PlayerAppearance>();
    }

    void Start()
    {
        // タグ "Crystal" を持つオブジェクトを探して Outline を取得
        GameObject[] crystals = GameObject.FindGameObjectsWithTag("Crystal");
        wallVisionTargets = new Outline[crystals.Length];

        for (int i = 0; i < crystals.Length; i++)
        {
            wallVisionTargets[i] = crystals[i].GetComponent<Outline>();
            if (wallVisionTargets[i] != null)
            {
                wallVisionTargets[i].enabled = false; // 最初は非表示
            }
            else
            {
                Debug.LogWarning(crystals[i].name + " に Outline が付いていません！");
            }
        }
        // 最初にリセットを呼ぶ
        ResetPowerUps();
        
        Debug.Log("Crystal オブジェクト数: " + crystals.Length);
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
                currentScoreMultiplier = boostedScoreMultiplier;
                break;

                case PowerUpType.WallHack:
                hasWallHack = true;
                EnableWallVision(true);
                break;
            }

        // 見た目をONにする
            if (appearance != null)
            {
                appearance.ApplyPowerUp(type);
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
            currentScoreMultiplier = defaultScoreMultiplier;

            EnableWallVision(false);
        }

        private void EnableWallVision(bool enable)
        {
            foreach (var outline in wallVisionTargets)

            if (outline != null)
            {
                outline.enabled = enable;
                Debug.Log($"Outline {outline.name} set to {enable}");
            }
            else
            {
                Debug.LogWarning("Outline reference is missing!");
            }
        }
}
