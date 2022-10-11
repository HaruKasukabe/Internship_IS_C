using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiar : MonoBehaviour
{
    // 変数宣言
    public int BulletTime = 30;     // 弾を打ち出す間隔
    public GameObject BulletObject; // 弾オブジェクト
    public float MoveSpeed = 0.01f; // 捕まっているときの移動スピード
    bool AliveFlg = false;          // デフォルトだと捕まっている
    GameObject Player;              // プレイヤーオブジェクト
    Vector3 OldPlayerPos;           // プレイヤーの1フレーム前の座標
    int NumFamiliar = 0;            // 現在の開放した使い魔の数
    public int MaxFamiliar = 20;    // 開放した使い魔の最大数


    // Start is called before the first frame update
    void Start()
    {
        // シーンからPlayerタグのオブジェクトを探してPlayer変数に代入
        Player = GameObject.FindWithTag("Player");
        // 開放した使い魔の数をリセット
        NumFamiliar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 捕まっている場合は移動のみ行う
        if(!AliveFlg)
        {
            this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);
            // 画面外にいくと
            if(!GetComponent<Renderer>().isVisible)
            {
                // このオブジェクト削除
                Destroy(this.gameObject);
            }
        }
        
        // 開放されている場合は移動と攻撃を行う
        if (AliveFlg)
        {
            BulletTime++; // 弾発射カウントをプラス
                          // 一定時間以上になったら弾を発射
            if (BulletTime >= 30 && Input.GetKey(KeyCode.Z))
            {
                BulletTime = 0; //カウントを0に
                                // 弾オブジェクト生成
                Instantiate(BulletObject,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                 Quaternion.identity);
            }
            // プレイヤーに追従
            //Vector3 pos = PlayerObject.transform.position;
            //pos.y =- 0.25f;
            //Debug.Log(pos);
            //this.transform.position = new Vector3(PlayerObject.transform.position.x, pos.y, PlayerObject.transform.position.z);
            this.transform.position = Player.transform.position;
        }
    }

    // 生きてるか判定するためにフラグを渡す
    public bool GetAliveFlg()
    {
        Debug.Log(AliveFlg + "を返します");
        return AliveFlg;
    }

    // 開放した際にフラグを反転させる
    public void SetAliveFlg()
    {
        AliveFlg = true;
        this.transform.position = Player.transform.position;
    }

    // Bulletとの当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 弾とあたったか
        if (collision.gameObject.tag == "Bullet")
        {
            // この使い魔のフラグがfalseなら
            if (!GetAliveFlg())
            {
                // フラグを反転&&移動
                SetAliveFlg();
                // 弾オブジェクトを削除
                Destroy(collision.gameObject);
            }
        }
    }

}
