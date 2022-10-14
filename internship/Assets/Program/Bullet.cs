using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾の移動速度
    public float MoveSpeed = 0.01f;
    public Enemy enemy;
    public Player_Bullet player_bullet;

    // 3Way弾の設定
    // 角度
    private float Angle_3Way;
    // 角度の間隔
    private float DevideAngle_3Way = 25.0f;
    // 移動ベクトル
    Vector3[] vec_3Way = new Vector3[3];
    // 拡散弾かどうかの判定
    string target_3Way = "3Way";

    // 5Way弾の設定
    // 角度
    private float Angle_5Way;
    // 角度の間隔
    private float DevideAngle_5Way = 36.0f;
    // 移動ベクトル
    Vector3[] vec_5Way = new Vector3[5];
    // 拡散弾かどうかの判定
    string target_5Way = "5Way";


    public static float Bullet_Power;

    // Start is called before the first frame update
    void Start()
    {
        float WaySpeedT = -MoveSpeed * 1000;
        if (this.gameObject.name.Contains(target_3Way))
        {
            Angle_3Way = 25.0f;
            Bullet_Power = 1.0f;


            // 角度をラジアンに変換
            for (int i = 0; i < Bullet_3Way.makesum; i++)
            {
                float rad = Angle_3Way * Mathf.Deg2Rad;

                // ラジアンから進行方向を設定
                Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);
                // 方向に速度を掛け合わせて移動ベクトルを求める
                vec_3Way[i] = direction * (WaySpeedT * Time.deltaTime);
                Angle_3Way -= DevideAngle_3Way;
            }
        }
        WaySpeedT = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //vec_3Way[0] = new Vector3(-0.02f, 0.01f, 0);
        //vec_3Way[1] = new Vector3(-0.02f, 0.00f, 0);
        //vec_3Way[2] = new Vector3(-0.02f,-0.01f, 0);

        if (this.gameObject.name == "Enemy_Bullet")
        {
            // 弾を移動
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
        }

        if (this.gameObject.name.Contains(target_3Way))
        {
            for (int i = 0; i < Bullet_3Way.makesum; i++)
            {
                string Sum = i.ToString();
                if (this.gameObject.name.Contains(Sum))
                {
                    transform.position += vec_3Way[i];
                    Debug.Log(vec_3Way[i]);
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

            Score.AddScore(enemy.GetEnemyScore());// スコア加算
            Destroy(this.gameObject);      // バレットを削除
            Destroy(collision.gameObject); // 敵を削除
        }
    }
}
