using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    // 敵を生成するタイマー
    public int CreateTimer = 60;
    public GameObject Enemy;
    public float EnemyPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateTimer++;
        if(CreateTimer>=120)
        {
            CreateTimer = 0;
            EnemyPos = Random.Range(-3, 3);
            // EnemyPos = Random.value;
            Instantiate(Enemy, new Vector3(9.0f, EnemyPos, 0.0f), Quaternion.identity);

        }
    }
}
