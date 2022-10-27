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
    public int CreaterTime = 600;

    // Start is called before the first frame update
    void Start()
    {
        CreateCout = 0;
        SelectEnemy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ポーズ中は何もしない
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        CreateCout++;
        if(CreateCout >= CreaterTime)
        {
            CreateCout = 0;
            EnemyPos = Random.Range(-3, 3);
            // EnemyPos = Random.value;
            // 3種類の敵からランダムに生成
            SelectEnemy = Random.Range(0, 3);
            switch(SelectEnemy)
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
        }
    }
}
