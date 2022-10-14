using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createfamiliar : MonoBehaviour
{
    // 変数宣言
    public int CreateFamiliarTime = 0; // 生成カウント変数
    public int MaxFamiliarTime = 120; // この時間になったら使い魔を生成する
    public GameObject FamiliarObject1; // 使い魔その1
    public GameObject FamiliarObject2; // 使い魔その2
    public GameObject FamiliarObject3; // 使い魔その3

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ポーズ中は何もしない
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        // 使い魔を生成するタイマーを更新
        CreateFamiliarTime++;
        // タイマー以上になったら
        if(CreateFamiliarTime >= MaxFamiliarTime)
        {
            // 0以上3未満の整数をランダム生成
            int i = Random.Range(0, 3);
            // 使い魔オブジェクトの配列を宣言
            GameObject[] FamiliarObject = { FamiliarObject1, FamiliarObject2, FamiliarObject3 };
            // 敵の位置を自動生成するためのランダム生成
            float j = Random.Range(-3, 3);
            // 画面右に使い魔を生成
            Instantiate(FamiliarObject[i],
                new Vector3(9.0f, j, 0.0f), Quaternion.identity);
            CreateFamiliarTime = 0;
        }
    }
}
