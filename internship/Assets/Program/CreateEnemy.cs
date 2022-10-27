using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    // 敵を生成するタイマー
    int CreateCout = 0;
    public GameObject EnemyRed;
    public GameObject EnemyPurple;
    public GameObject EnemyBlack;
    private int SelectEnemy;
    public float EnemyPos;
    private float CreaterTime;
    public float MaxCreaterTime = 600.0f;
    public float MinCreaterTime = 150.0f;

    public int Wave = 6000;
    private int WaveCount;

    // Start is called before the first frame update
    void Start()
    {
        CreaterTime = MaxCreaterTime;
        CreateCout = 0;
        SelectEnemy = 0;
        WaveCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ポーズ中は何もしない
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        if (CreaterTime > MinCreaterTime)
        {
            WaveCount++;
            if (WaveCount >= Wave)
            {
                CreaterTime *= 0.9f;
                Debug.Log("Wave更新 : " + CreaterTime);
                WaveCount = 0;
            }
        }
        else
        {
            CreaterTime = MinCreaterTime;
            Debug.Log("Wave更新 : STOP");
        }

        CreateCout++;
        if (CreateCout >= CreaterTime)
        {
            CreateCout = 0;
            EnemyPos = Random.Range(-4.2f, 4.2f);
            // EnemyPos = Random.value;
            // 3種類の敵からランダムに生成
            int DoubleOrSingle = Random.Range(0, 10);
            switch (DoubleOrSingle)
            {
                case 0:
                    SelectEnemy = Random.Range(0, 3);
                    EnemyPos = Random.Range(-4.2f, 4.2f);
                    switch (SelectEnemy)
                    {
                        case 0:
                            Instantiate(EnemyRed, new Vector3(9.0f, EnemyPos, 0.0f), Quaternion.identity);
                            break;

                        case 1:
                            Instantiate(EnemyPurple, new Vector3(9.0f, EnemyPos, 0.0f), Quaternion.identity);
                            break;

                        case 2:
                            Instantiate(EnemyBlack, new Vector3(9.0f, EnemyPos, 0.0f), Quaternion.identity);
                            break;

                        default:
                            break;
                    }
                    SelectEnemy = Random.Range(0, 3);
                    EnemyPos = Random.Range(-4.2f, 4.2f);
                    switch (SelectEnemy)
                    {
                        case 0:
                            Instantiate(EnemyRed, new Vector3(9.0f, EnemyPos, 0.0f), Quaternion.identity);
                            break;

                        case 1:
                            Instantiate(EnemyPurple, new Vector3(9.0f, EnemyPos, 0.0f), Quaternion.identity);
                            break;

                        case 2:
                            Instantiate(EnemyBlack, new Vector3(9.0f, EnemyPos, 0.0f), Quaternion.identity);
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    SelectEnemy = Random.Range(0, 3);
                    switch (SelectEnemy)
                    {
                        case 1:
                            Instantiate(EnemyRed, new Vector3(9.0f, EnemyPos, 0.0f), Quaternion.identity);
                            break;

                        case 2:
                            Instantiate(EnemyPurple, new Vector3(9.0f, EnemyPos, 0.0f), Quaternion.identity);
                            break;

                        case 3:
                            Instantiate(EnemyBlack, new Vector3(9.0f, EnemyPos, 0.0f), Quaternion.identity);
                            break;

                        default:
                            break;
                    }
                    break;
            }
        }
    }
}
