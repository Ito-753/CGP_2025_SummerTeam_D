using UnityEngine;
using System.Collections;

public class PunchController : MonoBehaviour
{
    private Animator animator;
    public Collider punchCollider;
    public float attackDuration = 0.5f; //コライダーが有効な時間
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("Mutant Punch Import-Settings");
            //パンチのコルーティンを開始
            StartCoroutine(PunchAttack());
        }
    }

    IEnumerator PunchAttack()
    {
        //攻撃コライダーを有効にする
        punchCollider.enabled = true;
        //指定した時間だけ待つ
        yield return new WaitForSeconds(attackDuration);
        //攻撃コライダーを無効に戻す
        punchCollider.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destructive Object"))
        Debug.Log("パンチが " + other.gameObject.name + "にヒットしました");

    }
}
