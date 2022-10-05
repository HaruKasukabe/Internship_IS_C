using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 敵の移動速度
    public float MoveSpeed = 0.01f;
    // Player_Bulletを参照するため
    Player_Bullet playerbullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 敵を等速で移動
        this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);

        // カメラ外に出たら削除
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }

    }
    // プレイヤーと当たったら
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーか使い魔にあたった場合
        if (collision.gameObject.tag == "Familiar" || collision.gameObject.tag == "Player")
        {
            // 使い魔がいる場合
            if (playerbullet.GetFamiliarNum() > 0)
            {
                Debug.Log("使い魔が1匹以上います");
                Destroy(collision.gameObject);
                playerbullet.SetFamiliarNum();
            }
            // 使い魔がいない場合
            else
            {
                Debug.Log("使い魔がいません");
                Destroy(collision.gameObject);
            }
        }

    }
}
