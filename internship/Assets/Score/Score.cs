using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // インスペクターでテキストオブジェクトを入れる
    public GameObject ScoreText;

    // スコア格納用
    static int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = ScoreText.GetComponent<Text>();

        // テキストの表示を入れ替える
        score_text.text = "Score : " + score;
    }

    // スコアを加算したい場所で呼び出す
    // Score.AddScore(10);
    // 引数 : １回で増やしたい値
    public static void AddScore(int num)
    {
        // 引数に入れた値を加算
        score += num;
    }
}
