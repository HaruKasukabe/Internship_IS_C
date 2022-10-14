using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    // 敵を生成するタイマー
    int CreateCout = 0;
    public GameObject Enemy;
    public float EnemyPos;
    public int CreaterTime = 600;

    // Start is called before the first frame update
    void Start()
    {
        CreateCout = 0;
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
            Instantiate(Enemy, new Vector3(9.0f, EnemyPos, 0.0f), Quaternion.identity);
        }
    }
}
