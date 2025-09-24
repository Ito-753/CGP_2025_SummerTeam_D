using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    public bool isGrounded;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            // 接地してるときはtrue
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            // 地面と離れたらfalse
            isGrounded = false;
        }
    }
}