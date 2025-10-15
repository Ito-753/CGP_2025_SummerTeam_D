using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    private int touchCount = 0; //パンチ回数宣言
    public ScoreCount Sm; //スコア宣言
    private int Status; //ステータス宣言

    [SerializeField] private Transform brokenPrefab; //破片のモデルへの置き換え宣言
    [SerializeField] private Vector3 launchVelocity = new Vector3(0, 5, 0); // 生成後に上方向へ力を与える

    private int clickCount = 0; //パンチ回数宣言２(直すべき)

    void OnTriggerEnter(Collider other)
    {
        // PunchObjectのついた物体との接触を検知
        if (other.gameObject.CompareTag("PunchObject"))
        {
            clickCount++;

            Debug.Log("クリック回数: " + clickCount);

            // 3回クリックされたら変化を起こす
            if (clickCount == 3)
            {
                Sm.Score += 100;
                TriggerEvent(); //破片への置き換えを実行
                clickCount = 0; // 必要ならリセット
            }
        }

        void TriggerEvent()
        {

            {
                // プレハブ(クリスタルの破片)を生成
                Transform brokenTransform = Instantiate(brokenPrefab, transform.position, transform.rotation);
                brokenTransform.localScale = transform.localScale;

                // Rigidbodyがある場合、velocityを設定
                Rigidbody rb = brokenTransform.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = launchVelocity;
                    rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
                }

                // 元のオブジェクトを破壊
                Destroy(gameObject);
            }
        }
    }
}

