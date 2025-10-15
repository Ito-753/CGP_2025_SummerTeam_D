using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcer : MonoBehaviour
{
    void Update()
    {
        // Enterキーで「Field」シーンへ
        if (Input.GetKeyDown(KeyCode.Return))  // KeyCode.Return は Enterキー
        {
            SceneManager.LoadScene("Stage");
        }

        // Spaceキーで「Asobikata」シーンへ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Asobikata");
        }
    }
}

