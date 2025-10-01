using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    private int touchCount = 0;
    public ScoreCount Sm;
    private int Status;
    //スコアの宣言
    [SerializeField] private Transform brokenPrefab;
    [SerializeField] private Vector3 launchVelocity = new Vector3(0, 5, 0); // 生成後に上方向へ飛ばす

    private int clickCount = 0;

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
                TriggerEvent();
                clickCount = 0; // 必要ならリセット
            }
        }

        void TriggerEvent()
        {

            {
                // プレハブを生成
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

