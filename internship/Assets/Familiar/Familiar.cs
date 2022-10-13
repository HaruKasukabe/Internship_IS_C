using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Familiar : MonoBehaviour
{
    // 変数宣言
    public int BulletTime = 30;             // 弾を打ち出す間隔
    public GameObject BulletObject;         // 弾オブジェクト
    public float CaptiveMoveSpeed = 0.01f; // 捕まっているときの移動スピード
    bool AliveFlg = false;                 // デフォルトだと捕まっている
    GameObject Player;                     // プレイヤーオブジェクト
    Vector3 OldPlayerPos;                  // プレイヤーの1フレーム前の座標
    public int MaxFamiliar = 20;           // 開放した使い魔の最大数
    int time;                              // プレイヤーが動いてからの経過時間
    float MoveSpeed = 0.01f;               // 開放時の移動速度
    bool Flg = true;                       // プレイヤーと同じ位置にいるか
    ManagerPosFamiliar m_PosFamiliar;      // 使い魔の位置を管理するスクリプトの呼び出し用
    Vector2 FixedPosition;                 // 使い魔の定位置
    Vector2 CalculationFPos;               // 計算後の定位置
    int FamiliarNum = -1;                  // 使い魔の個体番号


    // Start is called before the first frame update
    void Start()
    {
        // シーンからPlayerタグのオブジェクトを探してPlayer変数に代入
        Player = GameObject.FindWithTag("Player");
        m_PosFamiliar = GameObject.FindWithTag("Player").GetComponent<ManagerPosFamiliar>();
        // 開放した使い魔の数をリセット
    }

    // Update is called once per frame
    void Update()
    {
        // ポーズ中は何もしない
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        // 捕まっている場合は移動のみ行う
        if (!AliveFlg)
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
            // プレイヤーが動いた場合1フレーム前の位置を保存
            if (OldPlayerPos != Player.transform.position)
            {
                Debug.Log("プレイヤーが動きました");
                OldPlayerPos = Player.transform.position;
                CalculationFPos.x = Player.transform.position.x + FixedPosition.x;
                CalculationFPos.y = Player.transform.position.y + FixedPosition.y;
            }
            // 動いていないかつ使い魔が所定位置についている場合はタイマーをリセット
            else if((OldPlayerPos == Player.transform.position) && Flg)
            {
                Debug.Log("時間をリセットしました");
                time = 0;
            }

            // タイマーが一定時間以上になる
            if(time >= 60)
            {
                // 使い魔の位置がプレイヤーより右にいる場合
                if(this.transform.position.x > CalculationFPos.x)
                {
                    this.transform.Translate(-MoveSpeed, 0.0f, 0.0f);
                }
                // 使い魔の位置がプレイヤーより左にいる場合
                if (this.transform.position.x < CalculationFPos.x)
                {
                    this.transform.Translate( MoveSpeed, 0.0f, 0.0f);
                }
                // 使い魔の位置がプレイヤーより上にいる場合
                if (this.transform.position.y > CalculationFPos.y)
                {
                    this.transform.Translate( 0.0f, -MoveSpeed, 0.0f);
                }
                // 使い魔の位置がプレイヤーより下にいる場合
                if (this.transform.position.y < CalculationFPos.y)
                {
                    this.transform.Translate( 0.0f, MoveSpeed, 0.0f);
                }
            }
            if (( this.transform.position.x == CalculationFPos.x) && (this.transform.position.y== CalculationFPos.y))
            {
                Debug.Log("使い魔の現在地"+this.transform.position);
                Debug.Log("プレイヤーの現在地"+Player.transform.position);
                Debug.Log("使い魔の目的地"+ CalculationFPos);
                Flg = true;
            }
            else
            {
                Flg = false;
            }

            // タイマー更新
            time++;
        }
    }

    // 生きてるか判定するためにフラグを渡す
    public bool GetAliveFlg()
    {
        return AliveFlg;
    }

    // 開放した際にフラグを反転させる
    public void SetAliveFlg()
    {
        // 開放フラグをtrueにする
        AliveFlg = true;
        // 個体番号を取得する
        FamiliarNum = m_PosFamiliar.SetUseTrueFlg();
        // 個体番号から定位置を取得する
        FixedPosition = m_PosFamiliar.GetFamiliarPos(FamiliarNum);
        // 経過時間を61にして自動的に定位置に移動するようにする
        time = 61;
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

/*
    プレイヤーの斜め左上に使い魔を置く(移動後

 */ 