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
        Bullet_Power = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name != "Prefab_Seeker")
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
<<<<<<< HEAD
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("当たったのはEnemyでした");
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            player_bullet.CreatePlayer();
=======
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            player_bullet.CreatePlayer();  // 使い魔開放
            Score.AddScore(enemy.GetEnemyScore());// スコア加算
            Destroy(this.gameObject);      // バレットを削除
            Destroy(collision.gameObject); // 敵を削除
>>>>>>> fc932d55feba288e6d0bdc8b35010a937f195c89
        }
    }
}
