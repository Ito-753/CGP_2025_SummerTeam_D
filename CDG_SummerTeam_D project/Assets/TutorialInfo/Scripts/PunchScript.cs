using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Punch();
        }
    }
    void Punch()
    {
        

        Debug.Log("パンチ！");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destractive object"))
        {

        }
        Debug.Log("すり抜けた");
    }

}
