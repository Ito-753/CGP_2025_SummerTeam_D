using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeCount : MonoBehaviour
{
  public float countdown = 180f;

    public float timeLimit = 0f;
    //timeTextのフィールドにtextのオブジェクトを入れる
    public TextMeshProUGUI timeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        timeText.text = countdown.ToString("f1");

        if (countdown <= 0)
        {
            timeText.text = "End";
        }
        if (countdown < timeLimit - 3)
        {
            //制限時間を3秒過ぎてシーンを切り替える。""の中に次のシーンの名前を入れる
            SceneManager.LoadScene("");
        }

    }

}
