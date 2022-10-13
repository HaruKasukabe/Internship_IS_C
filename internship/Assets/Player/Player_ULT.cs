using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_ULT : MonoBehaviour
{
    private RectTransform obj;
    public GameObject ultimate;
    public TextMeshProUGUI readyUI;

    // 必殺技までのカウント
    static float ult_cnt = 0.0f;
    // 必殺技カウントの最大値
    public float ult_MaxCnt = 30.0f;
    // 必殺技を使ったか
    private bool play;
    // 汎用
    private float tmp;

    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<RectTransform>();

        readyUI.alpha = 0.0f;

        ult_cnt = 0.0f;
        play = false;
        tmp = ult_cnt;
    }

    // Update is called once per frame
    void Update()
    {
        // ポーズ中は何もしない
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;


        if (ult_MaxCnt <= ult_cnt)
        {
            readyUI.alpha = 1.0f;
        }
        else
        {
            readyUI.alpha = 0.0f;
        }

        if (!play)
        {
            // tmpを今のカウントまで少しずつ値を増やす
            if (ult_cnt >= tmp)
            {
                tmp += 0.05f;
            }

            // カウントが最大値で止まるようにする
            if (ult_MaxCnt < tmp)
            {
                ult_cnt = ult_MaxCnt;
                tmp = ult_MaxCnt;
            }
        }
        else
        {
            // カウントを0に戻す
            ult_cnt = 0.0f;

            // tmpを今のカウントまで少しずつ値を減らす
            if (ult_cnt <= tmp)
            {
                tmp--;
            }

            // tmpが0以下になったら
            if(tmp <= 0)
            {
                tmp = 0.0f;
                play = false;
            }
        }

        // カウントがいっぱいだったら
        if(ult_MaxCnt <= ult_cnt)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                Instantiate(ultimate, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                play = true;
            }
        }

        // オブジェクトの大きさを反映する
        obj.sizeDelta = new Vector2(tmp * 15.0f, 70.0f);
    }

    // 必殺技カウントを加算したい場所で呼び出す
    // Player_ULT.AddUltCnt();
    public static void AddUltCnt()
    {
        // 値を加算
        ult_cnt += 10.0f;
    }
}
