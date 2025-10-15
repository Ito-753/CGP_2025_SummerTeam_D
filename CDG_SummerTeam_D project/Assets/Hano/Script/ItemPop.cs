using UnityEngine;

public class NewMonoBehaviourScripItemPop : MonoBehaviour
{
    public GameObject itemprefab;
    public Transform spawnPoint;
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PunchObject"))
        {
            Instantiate(itemprefab, transform.position, Quaternion.identity);

            // 自身を破壊
            Destroy(gameObject);
        }

    }
}
