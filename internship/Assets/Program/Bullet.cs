using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾の移動速度
    public float MoveSpeed = 0.01f;
    public Enemy enemy;
    public Player_Bullet player_bullet;
    public static bool ScoreFlag;

    // 弾の威力
    public static float Bullet_Power;
    // 弾が使い魔のものかどうかを判定するための文字列
    private string Familiar_Name = "Familiar_Bullet";

    // 弾の威力
    public float Player_Power = 1;
    public float Fam_1_Power = 0.1f;
    public float Fam_2_Power = 0.25f;
    public float Fam_3_Power = 0.5f;

    // 消滅エフェクト
    public GameObject DeathEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ポーズ中は何もしない
        if (Mathf.Approximately(Time.timeScale, 0f))
            return;

        if (this.gameObject.name == "Player_Bullet" || gameObject.name.Contains(Familiar_Name))

        {
            // 弾を移動
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
            // 威力設定
            if(gameObject.name == "Player_Bullet")
            {
                Bullet_Power = Player_Power;
            }
            if(gameObject.name.Contains(Familiar_Name))
            {
                if(gameObject.name.Contains("1"))
                {
                    Bullet_Power = Fam_1_Power;
                }
                if (gameObject.name.Contains("2"))
                {
                    Bullet_Power = Fam_2_Power;
                }
                if (gameObject.name.Contains("3"))
                {
                    Bullet_Power = Fam_3_Power;
                }
            }
        }

        // カメラ外に出たら削除
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {          
            Destroy(this.gameObject);      // バレットを削除
            Destroy(collision.gameObject); // 敵を削除
            Score.AddScore(enemy.GetEnemyScore());// スコア加算
            Player_ULT.AddUltCnt();


            Instantiate(DeathEffect,
                    new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                    Quaternion.identity);
        }
    }
}
