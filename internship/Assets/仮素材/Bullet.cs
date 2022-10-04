using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾の移動速度
    public float MoveSpeed = 0.01f;

    public Player_Bullet player_bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 弾を移動
        this.transform.Translate(MoveSpeed, 0.0f, 0.0f);

        // カメラ外に出たら削除
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("当たりました");
        if(collision.gameObject.tag =="Enemy")
        {
            Debug.Log("当たったのはEnemyでした");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            player_bullet.CreatePlayer();
        }
    }
}
