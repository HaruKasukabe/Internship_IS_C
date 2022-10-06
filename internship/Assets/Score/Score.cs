using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // コンポーネント格納用
    Text score_text;

    // インスペクターでテキストオブジェクトを入れる
    public GameObject ScoreTextObj;

    // スコア格納用
    static int score = 0;

    // シーンの初めにスコアを'0'に戻すかのフラグ
    public bool ScoreReset = true;

    // Start is called before the first frame update
    void Start()
    {
        // true ならシーンのはじめに'0'に戻す
        if (ScoreReset)
            score = 0;

        // オブジェクトからTextコンポーネントを取得
        score_text = ScoreTextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // テキストの表示を入れ替える
        score_text.text = "Score : " + score;
    }

    // スコアを加算したい場所で呼び出す
    // Score.AddScore(10);
    // 引数 : １回で増やしたい値
    public static void AddScore(int num)
    {
        // 引数に入れた値を加算
        Debug.Log("加算する前");
        score += num;
        Debug.Log("加算する後");
    }
}
