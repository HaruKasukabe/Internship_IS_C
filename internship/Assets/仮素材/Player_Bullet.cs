using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    // プレイヤー移動の変数生成
    public float MoveSpeed = 0.01f;
    // プレイヤーの移動範囲制限
    public float MaxPosX = 8.0f;
    public float MinPosX = -8.0f;
    public float MaxPosY = 4.0f;
    public float MinPosY = -4.0f;
    // 生成する弾を選択
    public GameObject Bulletobj;
    // 弾を生成するタイマー
    public int BulletTimer = 60;
    // プレイヤーの体力
    public int HP;
    // 現在いる使い魔の数
    int NumFamiliar = 0;
    // 最大使い魔数
    public int Maxfamiliar = 20;
    
    // 点滅
    //SpriteRenderer
    SpriteRenderer sp;
    // 周期
    public int FlashingCycle = 30;
    // カウント
    private int FlashingCnt = 0;

    // シーン遷移してよいか
    public static bool ChangeScene = false;

    private void Awake()
    {
        NumFamiliar = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        NumFamiliar = 0;

        sp = GetComponent<SpriteRenderer>();

        ChangeScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ポーズ中は何もしない
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        // 弾生成タイマー更新
        BulletTimer++;
        // プレイヤー移動
        // 上
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0.0f, MoveSpeed, 0.0f);
        }
        // 下
        if (Input.GetKey(KeyCode.DownArrow))
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

        // 移動範囲に制限をかける
        var limitPos = transform.position;
        limitPos.x = Mathf.Clamp(limitPos.x, MinPosX, MaxPosX);
        limitPos.y = Mathf.Clamp(limitPos.y, MinPosY, MaxPosY);
        transform.position = limitPos;

        // 弾を生成
        if (Input.GetKey(KeyCode.Z) && BulletTimer >= 60)
        {
            BulletTimer = 0;

            Vector2 pos = this.transform.position;
            pos.x += 0.25f;
            Instantiate(Bulletobj,
                new Vector3(pos.x,this.transform.position.y,this.transform.position.z),
                Quaternion.identity);
        }

        // 弾に当たったら点滅
        if (ChangeScene)
        {
            FlashingCnt++;
            if (FlashingCnt >= FlashingCycle)
            {
                sp.enabled = !sp.enabled;
                FlashingCnt = 0;
            }
        }
    }
  
    // 現在の使い魔の数を取得
    public int GetFamiliarNum()
    {
        Debug.Log("使い魔を貸しました");
        return NumFamiliar;
    }
    // 使い魔を1匹減らす
    public void SetFamiliarNum()
    {
        Debug.Log("使い魔が減りました");
        NumFamiliar--;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "E_Bullet")
        {
            Destroy(other.gameObject);
            HP -= 1;
            if (HP <= 0)
            {
                ChangeScene = true;
            }
        }
    }
}
