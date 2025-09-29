using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = string.Format("{0}", Score);
    }
}
