using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾の移動速度
    public float MoveSpeed = 0.01f;
    public Enemy enemy;
    public Player_Bullet player_bullet;


    public static float Bullet_Power;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name == "Player_Bullet")
        {
            // 弾を移動
            this.transform.Translate(MoveSpeed, 0.0f, 0.0f);
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
