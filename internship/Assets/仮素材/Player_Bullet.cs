using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    // プレイヤー移動の変数生成
     public float MoveSpeed = 0.001f;
    // 生成する弾を選択
    public GameObject obj;
    // 弾を生成するタイマー
    public int BulletTimer = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 弾生成タイマー更新
        BulletTimer++;
        // プレイヤー移動
        // 上
        if(Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0.0f, MoveSpeed, 0.0f);
        }
        // 下
        if(Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0.0f, -MoveSpeed, 0.0f);
        }
        // 左
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);
        }
        // 右
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
        }
        // 弾を生成
        if(Input.GetKey(KeyCode.Z) && BulletTimer >= 60)
        {
            BulletTimer = 0;
            Instantiate(obj,
                new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z), 
                Quaternion.identity);
        }
        
    }
    // プレイヤーを増殖
    public void CreatePlayer()
    {
        Vector3 pos = this.transform.position;
        pos.y = -0.5f;
        Instantiate(this.gameObject,
            new Vector3(this.transform.position.x, pos.y, this.transform.position.z),
             Quaternion.identity);
    }
}
