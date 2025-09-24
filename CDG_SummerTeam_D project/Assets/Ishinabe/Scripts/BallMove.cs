using UnityEngine;


public class BallMove : MonoBehaviour
{
    public GroundChecker groundChecker;
    // Rigidbodyコンポーネント
    public Rigidbody rb;
    // 速度パラメータ
    public float speed;

    public float jumpForce = 5f;



    private void Update()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        // 水平方向の入力を受け取る(-1 ~ 1)の値
        float h = Input.GetAxis("Horizontal");
        // 垂直方向の入力を受け取る(-1 ~ 1)の値
        float v = Input.GetAxis("Vertical");

        // h, vを成分とした正規化方向ベクトルを作る
        Vector3 direction = new Vector3(h, 0, v).normalized;

        // 方向ベクトルの向きに力を加える。
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }
    private void Jump()
    {
        // --ここからジャンプの処理--
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }



}
