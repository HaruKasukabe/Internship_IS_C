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
    // 点滅
    //SpriteRenderer
    SpriteRenderer sp;
    // 周期
    public int FlashingCycle = 30;
    // カウント
    private int FlashingCnt = 0;

    // 消滅エフェクト
    public GameObject DeathEffect;

    // シーン遷移してよいか
    public static bool ChangeScene = false;

    // 射撃のSE
    public AudioClip ShotSE;
    // 被弾のSE
    public AudioClip DamageSE;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        ChangeScene = false;

        // コンポーネント取得　
        audioSource = GetComponent<AudioSource>();
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
            // audioSource.PlayOneShot(ShotSE);
            BulletTimer = 0;
            Vector2 pos = this.transform.position;
            pos.x += 1;
            pos.y -= 0.4f;

            var Bullet = Instantiate(Bulletobj,
                new Vector3(pos.x, pos.y, this.transform.position.z),
                Quaternion.identity);
            Bullet.name = "Player_Bullet";
            Debug.Log("弾を生成しました");
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

            Invoke("MeDestroy", 1.0f);
        }
    }

    private void MeDestroy()
    {
        Destroy(this.gameObject);

        Instantiate(DeathEffect,
                    new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                    Quaternion.identity);
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
