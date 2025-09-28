using UnityEngine;

//クリスタルにつける用
//ScoreCountに干渉する
//触れたらカウントアップし、三回になったら壊れてスコアアップ
public class ScoreUpCrystal : MonoBehaviour
{

    private int touchCount = 0;
    public ScoreCount Sm;
    private int Status;

    [SerializeField] private Transform brokenPrefab;
    [SerializeField] private Vector3 launchVelocity = new Vector3(0, 5, 0); // 生成後に上方向へ飛ばす
    void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトがパンチの攻撃範囲なのか判定
        if (other.gameObject.CompareTag("PunchObject"))
        {
            touchCount++;
            Debug.Log("PunchObjectに" + touchCount + "回触れた。");
        }
        if (touchCount == 3 && Status == 0)
        {
            Sm.Score += 100;
            TriggerEvent();
            Destroy(this.gameObject);
            Status = 1;

        }
        void TriggerEvent()

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject scoreObj = GameObject.Find("ScoreCount");
        if (scoreObj != null)
        {
            Sm = scoreObj.GetComponent<ScoreCount>();
        }
        else
        {
            Debug.LogError("ScoreCountオブジェクトが見つかりません");
        }

        //ScoreCount（別で作成したスコアを計測してくれるScript）を探す
        Sm = GameObject.Find("ScoreCount").GetComponent<ScoreCount>();
        Status = 0;

    }

    // Update is called once per frame

}
