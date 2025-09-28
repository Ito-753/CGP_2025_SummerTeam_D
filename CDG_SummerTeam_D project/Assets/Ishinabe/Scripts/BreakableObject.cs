using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private Transform brokenPrefab;
    [SerializeField] private Vector3 launchVelocity = new Vector3(0, 5, 0); // 生成後に上方向へ飛ばす

    private int clickCount = 0;

    void Update()
    {
        // マウスの左クリックを検知
        if (Input.GetMouseButtonDown(0))
        {
            clickCount++;

            Debug.Log("クリック回数: " + clickCount);

            // 3回クリックされたら変化を起こす
            if (clickCount == 3)
            {
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

