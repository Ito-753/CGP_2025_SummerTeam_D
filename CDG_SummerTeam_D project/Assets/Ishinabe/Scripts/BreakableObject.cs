using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [SerializeField] private GameObject brokenPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject brokenObject = Instantiate(brokenPrefab, transform.position, transform.rotation);
            brokenObject.transform.localScale = transform.localScale;
            Destroy(gameObject);
        }
    }
}
