using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // カメラが追従するターゲット
    public Vector3 cameraOffset;
    public float rotation_x = 0.0f; // カメラのX軸回転
    public float rotation_y = 0.0f; // カメラのY軸回転
    public float sensitivity_x = 2.0f; // マウスのX軸感度
    public float sensitivity_y = 2.0f; // マウスのY軸感度

    void Update()
    {
        transform.position = target.position + cameraOffset;
        // マウスの動きに応じてカメラを回転させる
        rotation_x += Input.GetAxis("Mouse X") * sensitivity_x;
        rotation_y += Input.GetAxis("Mouse Y") * sensitivity_y;

        // カメラの回転を適用
        transform.rotation = Quaternion.Euler(rotation_y, rotation_x, 0);
    }
}