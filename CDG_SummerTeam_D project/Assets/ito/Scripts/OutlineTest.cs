using UnityEngine;

public class OutlineTest : MonoBehaviour
{
    private Outline outline;

    void Start()
    {
        outline = GetComponent<Outline>();

        // 最初はオフにしておく
        outline.enabled = false;
    }

}


